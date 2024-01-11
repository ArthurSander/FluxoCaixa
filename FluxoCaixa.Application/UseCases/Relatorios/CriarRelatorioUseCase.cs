using FluentResults;
using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Application.Mappers.Relatorios.Interfaces;
using FluxoCaixa.Application.UseCases.Relatorios.Interfaces;
using FluxoCaixa.Application.Validators;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;
using FluxoCaixa.Domain.Repositories.Relatorios;
using FluxoCaixa.Domain.Services.Relatorios;
using FluxoCaixa.Shared.Results.Relatorios;
using Serilog;

namespace FluxoCaixa.Application.UseCases.Relatorios
{
    public class CriarRelatorioUseCase : ICriarRelatorioUseCase
    {
        protected readonly ILogger _logger;
        protected readonly IRelatorioReadRepository _relatorioReadRepository;
        protected readonly IRelatorioService _domainService;
        protected readonly IValidator<CriarRelatorioDto> _validator;
        protected readonly IRelatorioApplicationMapper _mapper;

        public CriarRelatorioUseCase(ILogger logger, IRelatorioReadRepository relatorioReadRepository, IRelatorioService domainService, IValidator<CriarRelatorioDto> validator, IRelatorioApplicationMapper mapper)
        {
            _logger = logger;
            _relatorioReadRepository = relatorioReadRepository;
            _domainService = domainService;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Relatorio>> ExecutarAsync(CriarRelatorioDto input, CancellationToken ct = default)
        {
            var validation = _validator.Validar(input);
            if (validation.IsFailed)
                return validation;

            var idCaixa = input.IdCaixa.Value;
            var caixaExiste = await _relatorioReadRepository.VerificarCaixaExisteAsync(idCaixa);

            if (caixaExiste.IsFailed)
                return new CaixaNaoExisteResult($"Caixa não existe. Id informado: {idCaixa}");

            var relatorio = _mapper.MapearNovoRelatorio(input, StatusRelatorio.NaFila);

            return await _domainService.CriarRelatorioAsync(relatorio, idCaixa);
        }
    }
}

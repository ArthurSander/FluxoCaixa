using FluentResults;
using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.Services.FluxoCaixa;
using FluxoCaixa.Application.UseCases.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.Validators;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Services.FluxoCaixa;

namespace FluxoCaixa.Application.UseCases.FluxoCaixa
{
    public class AdicionarLancamentoUseCase : IAdicionarLancamentoUseCase
    {
        private readonly IFluxoCaixaService _domainService;
        private readonly IFluxoCaixaApplicationService _applicationService;
        private readonly IValidator<AdicionarLancamentoDto> _validator;
        private readonly ILancamentoApplicationMapper _mapper;

        public AdicionarLancamentoUseCase(
            IFluxoCaixaService domainService,
            IFluxoCaixaApplicationService applicationService,
            IValidator<AdicionarLancamentoDto> validator,
            ILancamentoApplicationMapper mapper
            )
        {
            _domainService = domainService;
            _applicationService = applicationService;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Caixa>> ExecutarAsync(AdicionarLancamentoDto input, CancellationToken ct = default)
        {
            var validacao = _validator.Validar(input);
            if (validacao.IsFailed)
                return validacao;

            var resultadoBuscaCaixa = await _applicationService.ObterCaixaObrigatoriaAsync(input.IdCaixa.Value, ct);
            if(resultadoBuscaCaixa.IsFailed)
                return resultadoBuscaCaixa;

            var lancamento = _mapper.MapearLancamento(input);

            return await _domainService.ComputarLancamentoAsync(resultadoBuscaCaixa.Value, lancamento, ct);
        }
    }
}

using FluentResults;
using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.UseCases.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.Validators;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Services.FluxoCaixa;

namespace FluxoCaixa.Application.UseCases.FluxoCaixa
{
    public class CriarCaixaUseCase : ICriarCaixaUseCase
    {
        protected readonly IFluxoCaixaService _domainService;
        protected readonly ICaixaApplicationMapper _caixaMapper;
        protected readonly ILancamentoFactory _lancamentoFactory;
        protected readonly IValidator<CriarCaixaDto> _validator;

        public CriarCaixaUseCase(IFluxoCaixaService domainService, ICaixaApplicationMapper caixaMapper, 
            IValidator<CriarCaixaDto> validator, ILancamentoFactory lancamentoFactory)
        {
            _domainService = domainService;
            _validator = validator;
            _caixaMapper = caixaMapper;
            _lancamentoFactory = lancamentoFactory;
        }

        public async Task<Result<Caixa>> ExecutarAsync(CriarCaixaDto input, CancellationToken ct = default)
        {
            var validacao = _validator.Validar(input);
            if (validacao.IsFailed)
                return validacao;

            var caixa = _caixaMapper.MapearCaixa(input);

            var resultadoCriacao = await _domainService.CriarCaixaAsync(caixa);

            if(resultadoCriacao.IsFailed)
                return resultadoCriacao;

            if (input.SaldoInicial > 0)
                resultadoCriacao = await _domainService.ComputarLancamentoAsync(resultadoCriacao.Value,
                    _lancamentoFactory.Criar(TipoLancamento.Credito, "Saldo inicial", input.SaldoInicial.Value, DateTime.UtcNow));

            return resultadoCriacao;
        }
    }
}

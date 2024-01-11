using FluentResults;
using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.UseCases.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Repositories.FluxoCaixa;
using FluxoCaixa.Domain.Results;
using FluxoCaixa.Shared.Logs;
using FluxoCaixa.Shared.Results.FluxoCaixa;
using Serilog;

namespace FluxoCaixa.Application.UseCases.FluxoCaixa
{
    public class ConsultarSaldoUseCase : IConsultarSaldoUseCase
    {
        protected readonly ICaixaReadRepository _caixaReadRepository;
        protected readonly ICaixaApplicationMapper _mapper;
        protected readonly ILogger _logger;

        public ConsultarSaldoUseCase(ICaixaReadRepository caixaReadRepository, ICaixaApplicationMapper mapper, ILogger logger)
        {
            _caixaReadRepository = caixaReadRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ConsultarSaldoDto>> ExecutarAsync(int input, CancellationToken ct = default)
        {
            var resultadoConsulta = await _caixaReadRepository.ConsultarAsync(input, ct);

            if (resultadoConsulta.IsFailed || resultadoConsulta.Value == null)
            {
                _logger.Warning($"{LogVariables.ClassAndMethodName} Caixa não encontrada.",
                    nameof(ConsultarSaldoUseCase), nameof(ExecutarAsync));
                return new CaixaNaoEncontradaResult(resultadoConsulta.GetFirstErrorMessage() ?? "Caixa não encontrada");
            }

            return _mapper.MapearConsultaSaldo(resultadoConsulta.Value);
        }
    }
}

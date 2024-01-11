using FluentResults;
using FluxoCaixa.Domain.Repositories.Relatorios;
using FluxoCaixa.Domain.Services.Relatorios;
using FluxoCaixa.Shared.Logs;
using Serilog;

namespace FluxoCaixa.Application.Services.Relatorios
{
    public class RelatorioApplicationService : IRelatorioApplicationService
    {
        protected readonly IRelatorioReadRepository _relatorioReadRepository;
        protected readonly ILogger _logger;
        protected readonly IRelatorioService _domainService;

        public RelatorioApplicationService(IRelatorioReadRepository relatorioReadRepository, ILogger logger, IRelatorioService domainService)
        {
            _relatorioReadRepository = relatorioReadRepository;
            _logger = logger;
            _domainService = domainService;
        }

        public async Task<Result> IniciarGeracaoRelatorioAsync(int idRelatorio, CancellationToken cancellationToken = default)
        {
            var consultaRelatorio = await _relatorioReadRepository.BuscarRelatorioComCaixaAsync(idRelatorio, cancellationToken);
            if(consultaRelatorio.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Não foi possível encontrar o relatório. {LogVariables.RelatorioId}",
                    nameof(RelatorioApplicationService), nameof(IniciarGeracaoRelatorioAsync), idRelatorio);
                return consultaRelatorio.ToResult();
            }

            return await _domainService.GerarRelatorioAsync(consultaRelatorio.Value);
        }
    }
}

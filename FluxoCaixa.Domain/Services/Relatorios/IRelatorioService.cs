using FluentResults;
using FluxoCaixa.Domain.Contexts.Relatorios;

namespace FluxoCaixa.Domain.Services.Relatorios
{
    public interface IRelatorioService
    {
        Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken cancellationToken = default);

        Task<Result> GerarRelatorioAsync(Relatorio relatorio, CancellationToken cancellationToken = default);
    }
}

using FluentResults;
using FluxoCaixa.Domain.Contexts.Relatorios;

namespace FluxoCaixa.Domain.Repositories.Relatorios
{
    public interface IRelatorioWriteRepository
    {
        Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken ct = default);
        Task<Result> AtualizarRelatorioAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}

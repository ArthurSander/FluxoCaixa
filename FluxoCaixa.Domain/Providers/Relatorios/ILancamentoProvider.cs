using FluentResults;
using FluxoCaixa.Domain.Contexts.Relatorios;

namespace FluxoCaixa.Domain.Providers.Relatorios
{
    public interface ILancamentoProvider
    {
        Task<Result> ExecutarAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}

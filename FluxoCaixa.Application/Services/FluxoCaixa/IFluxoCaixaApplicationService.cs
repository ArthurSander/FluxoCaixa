using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.Application.Services.FluxoCaixa
{
    public interface IFluxoCaixaApplicationService
    {
        Task<Result<Caixa>> ObterCaixaObrigatoriaAsync(int caixaId, CancellationToken ct = default);
    }
}

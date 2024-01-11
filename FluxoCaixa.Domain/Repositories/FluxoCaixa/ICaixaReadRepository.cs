using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.Domain.Repositories.FluxoCaixa
{
    public interface ICaixaReadRepository
    {
        Task<Result<Caixa>> ConsultarAsync(int id, CancellationToken ct = default);
    }
}

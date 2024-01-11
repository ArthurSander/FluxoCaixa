using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;

namespace FluxoCaixa.Domain.Services.FluxoCaixa
{
    public interface IFluxoCaixaService
    {
        Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default);
        Task<Result<Caixa>> ComputarLancamentoAsync(Caixa caixa, ILancamento lancamento, CancellationToken ct = default);
    }
}

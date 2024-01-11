using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;

namespace FluxoCaixa.Domain.Repositories.FluxoCaixa
{
    public interface ICaixaWriteRepository
    {
        Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default);
        Task<Result<int>> AdicionarLancamentoAsync(int caixaId, ILancamento lancamento, NovoLancamento eventoLancamento, CancellationToken ct = default);
    }
}

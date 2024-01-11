using FluentResults;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos;

namespace FluxoCaixa.Domain.Builder.Relatorios
{
    public interface IRelatorioBuilder
    {
        void SetRelatorio(Relatorio relatorio);
        void AdicionarLancamento(Lancamento lancamento);
        Task<Result<string>> EscreverRelatorioAsync(CancellationToken ct = default);
    }
}

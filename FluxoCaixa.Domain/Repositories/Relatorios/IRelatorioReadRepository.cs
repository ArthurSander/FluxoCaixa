using FluentResults;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;
using FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos;

namespace FluxoCaixa.Domain.Repositories.Relatorios
{
    public interface IRelatorioReadRepository
    {
        Task<Result> VerificarCaixaExisteAsync(int idCaixa, CancellationToken ct = default);
        Task<Result<Relatorio>> BuscarRelatorioComCaixaAsync(int id, CancellationToken ct = default);
        Task<Result<Relatorio>> BuscarRelatorioAsync(int id, CancellationToken ct = default);
        IQueryable<Lancamento> BuscarQueryLancamentosParaRelatorio(Relatorio relatorio);
        Task<double> BuscarUltimoSaldoRegistradoAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}

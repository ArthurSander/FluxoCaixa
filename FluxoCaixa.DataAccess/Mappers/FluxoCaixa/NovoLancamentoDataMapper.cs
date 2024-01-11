using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;

namespace FluxoCaixa.DataAccess.Mappers.FluxoCaixa
{
    public class NovoLancamentoDataMapper : IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento>
    {
        public NovoLancamento ToEntity(NovoLancamentoDataModel model)
        {
            return new NovoLancamento(model.SaldoAnterior, model.SaldoAtual, model.CaixaId, model.LancamentoId);
        }

        public NovoLancamentoDataModel ToModel(NovoLancamento entity)
        {
            return new NovoLancamentoDataModel()
            {
                SaldoAtual = entity.SaldoAtual,
                SaldoAnterior = entity.SaldoAnterior,
                CaixaId = entity.CaixaId,
                LancamentoId = entity.LancamentoId
            };
        }
    }
}

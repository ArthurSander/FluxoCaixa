using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;

namespace FluxoCaixa.DataAccess.Mappers.FluxoCaixa
{
    public class LancamentoDataMapper : IDefaultDataModelMapper<LancamentoDataModel, ILancamento>
    {
        protected readonly ILancamentoFactory _factory;

        public LancamentoDataMapper(ILancamentoFactory factory) 
        {
            _factory = factory;
        }

        public ILancamento ToEntity(LancamentoDataModel model)
        {
            return _factory.Criar(model.Tipo, model.Descricao, model.Valor, model.DataLancamento, model.Id);
        }

        public LancamentoDataModel ToModel(ILancamento entity)
        {
            return new LancamentoDataModel()
            {
                Id = entity.Id,
                Tipo = entity.Tipo,
                Descricao = entity.Descricao,
                Valor = entity.Valor,
                DataLancamento = entity.DataHora
            };
        }
    }
}

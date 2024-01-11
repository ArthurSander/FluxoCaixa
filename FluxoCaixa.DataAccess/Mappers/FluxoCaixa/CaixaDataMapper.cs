using FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.DataAccess.Mappers.FluxoCaixa
{
    public class CaixaDataMapper : ICaixaDataMapper
    {
        public Caixa ToEntity(CaixaDataModel model, double saldoAtual)
        {
            return new Caixa(model.Id, model.Nome, saldoAtual);
        }

        public CaixaDataModel ToModel(Caixa entity)
        {
            return new CaixaDataModel()
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}

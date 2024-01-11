using FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;

namespace FluxoCaixa.DataAccess.Mappers.Relatorios
{
    public class CaixaDataMapper : ICaixaDataMapper
    {
        public Caixa ToEntity(CaixaDataModel model)
        {
            return new Caixa(model.Id, model.Nome);
        }
    }
}

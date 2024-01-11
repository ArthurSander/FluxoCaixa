using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;

namespace FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces
{
    public interface ICaixaDataMapper
    {
        Caixa ToEntity(CaixaDataModel model);
    }
}

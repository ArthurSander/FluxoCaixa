using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces
{
    public interface ICaixaDataMapper
    {
        Caixa ToEntity(CaixaDataModel model, double saldoAtual);
        CaixaDataModel ToModel(Caixa caixa);
    }
}

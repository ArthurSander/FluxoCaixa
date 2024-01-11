using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;

namespace FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioDataMapper
    {
        Relatorio ToEntity(RelatorioDataModel model, Caixa caixa = null);
        RelatorioDataModel ToModel(Relatorio relatorio, int idCaixa);
        void UpdateData(Relatorio relatorio, RelatorioDataModel model);
    }
}

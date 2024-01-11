using FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;

namespace FluxoCaixa.DataAccess.Mappers.Relatorios
{
    public class RelatorioDataMapper : IRelatorioDataMapper
    {
        public Relatorio ToEntity(RelatorioDataModel model, Caixa caixa = null)
        {
            return new Relatorio(model.Id, model.Data, model.Tipo, model.Status, model.CaminhoArquivo, caixa);
        }

        public RelatorioDataModel ToModel(Relatorio relatorio, int idCaixa)
        {
            return new RelatorioDataModel()
            {
                Data = relatorio.Data,
                Tipo = relatorio.Tipo,
                Status = relatorio.Status,
                IdCaixa = idCaixa,
                CaminhoArquivo = relatorio.CaminhoArquivo
            };
        }

        public void UpdateData(Relatorio relatorio, RelatorioDataModel model)
        {
            model.Status = relatorio.Status;
            model.CaminhoArquivo = relatorio.CaminhoArquivo;
        }
    }
}

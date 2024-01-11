using FluxoCaixa.DataAccess.Models.Interfaces;

namespace FluxoCaixa.DataAccess.Models
{
    public class CaixaDataModel : IDataModel<int>, IDateInfoDataModel
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string Nome { get; set; }

        public ICollection<LancamentoDataModel> Lancamentos { get; set; }
        public ICollection<NovoLancamentoDataModel> HistoricoLancamentos { get; set; }
    }
}

using FluxoCaixa.DataAccess.Models.Interfaces;

namespace FluxoCaixa.DataAccess.Models
{
    public class NovoLancamentoDataModel : IDataModel<int>
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public int LancamentoId { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoAtual { get; set; }

        public CaixaDataModel Caixa { get; set; }
    }
}

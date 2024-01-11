using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos
{
    public class Lancamento
    {
        public Lancamento(int id, string descricao, double valor, double saldoAntes, 
            double saldoDepois, TipoLancamento tipo, DateTime dataHora)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            SaldoAntes = saldoAntes;
            SaldoDepois = saldoDepois;
            Tipo = tipo;
            DataHora = dataHora;
        }

        public int Id { get; protected set; }
        public string Descricao { get; protected set; }
        public double Valor { get; protected set; }
        public double SaldoAntes { get; protected set; }
        public double SaldoDepois { get; protected set; }
        public TipoLancamento Tipo { get; protected set; }
        public DateTime DataHora { get; protected set; }
    }
}

using FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos;

namespace FluxoCaixa.Domain.Contexts.Relatorios.Caixas
{
    public class Caixa
    {
        public Caixa(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Lancamentos = new List<Lancamento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double SaldoFinal { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }

        public void AddLancamento(Lancamento lancamento)
        {
            SaldoFinal = lancamento.SaldoDepois;
            Lancamentos.Add(lancamento);
        }
    }
}

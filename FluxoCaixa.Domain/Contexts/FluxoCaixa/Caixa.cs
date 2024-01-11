using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Saldos;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa
{
    public class Caixa
    {
        protected Caixa() { }

        public Caixa(string nome, double saldoInicial = 0)
        {
            Nome = nome;
            Lancamentos = new List<ILancamento>();
            HistoricoLancamentos = new List<NovoLancamento>();
            Saldo = new Saldo(saldoInicial, this);
        }

        public Caixa(int id, string nome, double saldoAtual) 
        {
            Id = id;
            Nome = nome;
            Saldo = new Saldo(saldoAtual, this);
            Lancamentos = new List<ILancamento>();
            HistoricoLancamentos = new List<NovoLancamento>();
        }

        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual Saldo Saldo { get; protected set; }
        public virtual List<ILancamento> Lancamentos { get; protected set; }
        public virtual List<NovoLancamento> HistoricoLancamentos { get; protected set; }

        public virtual Result<NovoLancamento> AdicionarLancamento(ILancamento lancamento)
        {
            var evento = Saldo.Contabilizar(lancamento);

            if (evento.IsFailed)
                return evento.ToResult();

            Lancamentos.Add(lancamento);
            HistoricoLancamentos.Add(evento.Value);

            return evento.Value;
        }
    }
}

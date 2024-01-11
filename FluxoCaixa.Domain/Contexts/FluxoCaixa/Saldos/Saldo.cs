using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Saldos
{
    public class Saldo
    {
        protected readonly Caixa _caixa;

        protected Saldo() { }

        public Saldo(double valor, Caixa caixa)
        {
            Valor = valor;
            _caixa = caixa;
        }

        public double Valor { get; protected set; }

        public virtual Result<NovoLancamento> Contabilizar(ILancamento lancamento)
        {
            var resultadoLancamento = lancamento.Lancar(Valor);
            if (resultadoLancamento.IsFailed)
                return resultadoLancamento.ToResult();

            var eventoLancamento = new NovoLancamento(Valor, resultadoLancamento.Value, _caixa.Id, lancamento.Id);

            AtualizarSaldo(resultadoLancamento.Value);

            return eventoLancamento;
        }

        protected void AtualizarSaldo(double novoSaldo) => Valor = novoSaldo;
    }
}

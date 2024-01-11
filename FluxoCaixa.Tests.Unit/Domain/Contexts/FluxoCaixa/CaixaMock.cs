using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Saldos;

namespace FluxoCaixa.Tests.Unit.Domain.Contexts.FluxoCaixa
{
    public class CaixaMock : Caixa
    {
        public CaixaMock(string nome, double saldoInicial = 0) : base(nome, saldoInicial)
        {
        }

        public void SetSaldo(Saldo saldo) => Saldo = saldo;
        public void SetId(int id) => Id = id;
    }
}

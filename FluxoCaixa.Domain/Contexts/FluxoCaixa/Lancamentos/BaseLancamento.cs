using FluentResults;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using FluxoCaixa.Shared.Extensions;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos
{
    public abstract class BaseLancamento : ILancamento
    {
        protected BaseLancamento(int? id = null)
        {
            if (id.IsGreaterThanZero())
                Id = id.Value;
        }

        public int Id { get; protected set; }
        public double Valor { get; protected set; }
        public string Descricao { get; protected set; }
        public TipoLancamento Tipo { get; protected set; }
        public DateTime DataHora { get; protected set; }

        public void Criado(int id) => Id = id;

        public abstract Result<double> Lancar(double saldoAtual);
    }
}

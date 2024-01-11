using FluentResults;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos
{
    public class LancamentoCredito : BaseLancamento
    {
        protected LancamentoCredito(int? id = null) : base(id) { }
        public override Result<double> Lancar(double saldoAtual)
        {
            return saldoAtual + Valor;
        }

        public static LancamentoCredito Novo(double valor, string descricao, DateTime? lancadoEm = null, int? id = null)
        {
            lancadoEm = lancadoEm ?? DateTime.UtcNow;

            return new LancamentoCredito(id)
            {
                Valor = valor,
                DataHora = lancadoEm.Value,
                Tipo = TipoLancamento.Credito,
                Descricao = descricao
            };
        }
    }
}

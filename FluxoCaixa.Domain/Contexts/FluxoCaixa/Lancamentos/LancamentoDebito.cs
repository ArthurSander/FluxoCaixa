using FluentResults;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos
{
    public class LancamentoDebito : BaseLancamento
    {
        protected LancamentoDebito(int? id = null): base(id) { }

        public override Result<double> Lancar(double saldoAtual)
        {
            var resultado = saldoAtual - Valor;

            if (resultado < 0)
                return Result.Fail("Saldo insuficiente para realizar a operação.");

            return resultado;
        }

        public static LancamentoDebito Novo(double valor, string descricao, DateTime? lancadoEm = null, int? id = null)
        {
            lancadoEm = lancadoEm ?? DateTime.UtcNow;

            return new LancamentoDebito(id)
            {
                Valor = valor,
                DataHora = lancadoEm.Value,
                Tipo = TipoLancamento.Debito,
                Descricao = descricao,
            };
        }
    }
}

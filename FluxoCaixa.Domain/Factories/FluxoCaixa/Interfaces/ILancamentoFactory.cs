using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces
{
    public interface ILancamentoFactory
    {
        ILancamento Criar(TipoLancamento tipo, string descricao, double valor, DateTime? dataLancamento = null, int? id = null);
    }
}

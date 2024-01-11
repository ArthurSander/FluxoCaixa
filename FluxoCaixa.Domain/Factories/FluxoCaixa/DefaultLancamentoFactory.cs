using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;
using FluxoCaixa.Shared.Logs;
using Serilog;

namespace FluxoCaixa.Domain.Factories.FluxoCaixa
{
    public class DefaultLancamentoFactory : ILancamentoFactory
    {
        protected readonly ILogger _logger;

        public DefaultLancamentoFactory(ILogger logger)
        { 
            _logger = logger;
        }

        public ILancamento Criar(TipoLancamento tipo, string descricao, double valor, DateTime? dataLancamento = null, int? id = null)
        {
            switch (tipo)
            {
                case TipoLancamento.Debito:
                    return LancamentoDebito.Novo(valor, descricao, dataLancamento, id);

                case TipoLancamento.Credito:
                    return LancamentoCredito.Novo(valor, descricao, dataLancamento, id);
            };

            _logger.Error($"{LogVariables.ClassAndMethodName} Não foi possível criar a instância de lançamento: Tipo inválido.",
                nameof(DefaultLancamentoFactory), nameof(Criar));

            throw new ArgumentException("Tipo informado é inválido.", nameof(tipo));
        }
    }
}

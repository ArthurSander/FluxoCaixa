using FluentResults;

namespace FluxoCaixa.Shared.Results.Relatorios
{
    public class RelatorioNaoGeradoResult : BaseErrorResult
    {
        public RelatorioNaoGeradoResult(string message) : base(message)
        {
        }

        public RelatorioNaoGeradoResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}

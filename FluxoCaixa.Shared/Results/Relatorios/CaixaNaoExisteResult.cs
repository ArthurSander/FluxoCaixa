using FluentResults;

namespace FluxoCaixa.Shared.Results.Relatorios
{
    public class CaixaNaoExisteResult : BaseErrorResult
    {
        public CaixaNaoExisteResult(string message) : base(message)
        {
        }

        public CaixaNaoExisteResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}

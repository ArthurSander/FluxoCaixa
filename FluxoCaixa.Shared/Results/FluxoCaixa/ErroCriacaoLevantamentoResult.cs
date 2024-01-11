using FluentResults;

namespace FluxoCaixa.Shared.Results.FluxoCaixa
{
    public class ErroCriacaoLevantamentoResult : BaseErrorResult
    {
        public ErroCriacaoLevantamentoResult(string message) : base(message)
        {
        }

        public ErroCriacaoLevantamentoResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}

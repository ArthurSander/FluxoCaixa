using FluentResults;

namespace FluxoCaixa.Shared.Results.FluxoCaixa
{
    public class ErroConsultaCaixaResult : BaseErrorResult
    {
        public ErroConsultaCaixaResult(string message) : base(message)
        {
        }

        public ErroConsultaCaixaResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}

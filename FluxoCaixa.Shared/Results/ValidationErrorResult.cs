using FluentResults;
using FluxoCaixa.Shared.Results;

namespace FluxoCaixa.Domain.Results
{
    public class ValidationErrorResult : BaseErrorResult
    {
        public ValidationErrorResult(string message) : base(message)
        {
        }

        public ValidationErrorResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}

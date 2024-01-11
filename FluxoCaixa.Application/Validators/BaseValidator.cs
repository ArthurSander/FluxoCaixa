using FluentResults;
using FluxoCaixa.Domain.Results;

namespace FluxoCaixa.Application.Validators
{
    public abstract class BaseValidator<T> : IValidator<T>
    {
        public abstract Result Validar(T value);

        protected Result obterResultado(IEnumerable<string> errorMessages)
        {
            if(errorMessages.Any())
                return Result.Fail("Input inválido.")
                    .WithErrors(errorMessages.Select(x => new ValidationErrorResult(x)));

            return Result.Ok();
        }
    }
}

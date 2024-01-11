using FluentResults;

namespace FluxoCaixa.Application.Validators
{
    public interface IValidator<T>
    {
        Result Validar(T value);
    }
}

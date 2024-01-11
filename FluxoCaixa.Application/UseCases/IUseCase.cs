using FluentResults;

namespace FluxoCaixa.Application.UseCases
{
    public interface IUseCase<TInput, TOutput>
    {
        Task<Result<TOutput>> ExecutarAsync(TInput input, CancellationToken ct = default);
    }
}

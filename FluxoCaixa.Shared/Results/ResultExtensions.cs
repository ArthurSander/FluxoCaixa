using FluentResults;

namespace FluxoCaixa.Domain.Results
{
    public static class ResultExtensions
    {
        public static string? GetFirstErrorMessage<T>(this IResult<T> result)
            => result.Errors.FirstOrDefault()?.Message;
    }
}

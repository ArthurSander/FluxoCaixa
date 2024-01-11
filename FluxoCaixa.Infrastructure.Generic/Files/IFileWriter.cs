using FluentResults;

namespace FluxoCaixa.Infrastructure.Generic.Files
{
    public interface IFileWriter
    {
        Task<Result<string>> WriteAsync(byte[] toWrite, string nomeArquivo, CancellationToken ct = default, string extensao = null);
    }
}

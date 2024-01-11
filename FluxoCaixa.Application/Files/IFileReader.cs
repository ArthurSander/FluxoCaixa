using FluentResults;
using FluxoCaixa.Application.Dtos;

namespace FluxoCaixa.Application.Files
{
    public interface IFileReader
    {
        Result<FileDto> ObterArquivo(string path);
    }
}

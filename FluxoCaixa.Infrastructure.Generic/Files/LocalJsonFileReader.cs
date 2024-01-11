using FluentResults;
using FluxoCaixa.Application.Dtos;
using FluxoCaixa.Application.Files;
using Serilog;

namespace FluxoCaixa.Infrastructure.Generic.Files
{
    public class LocalJsonFileReader : IFileReader
    {
        private readonly ILogger _logger;

        public LocalJsonFileReader(ILogger logger)
        {
            _logger = logger;
        }

        public Result<FileDto> ObterArquivo(string path)
        {
            try
            {
                var bytes = File.ReadAllBytes(path);
                var fileName = Path.GetFileName(path);

                return new FileDto()
                {
                    Conteudo = bytes,
                    MimeType = "application/json",
                    Nome = fileName
                };
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Ocorreu um erro ao tentar realizar o download do arquivo solicitado.");
                return Result.Fail("Ocorreu um erro no download do arquivo.");
            }
        }
    }
}

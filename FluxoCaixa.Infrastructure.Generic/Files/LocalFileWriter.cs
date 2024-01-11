using FluentResults;
using FluxoCaixa.Shared.Logs;
using Serilog;

namespace FluxoCaixa.Infrastructure.Generic.Files
{
    public class LocalFileWriter : IFileWriter
    {
        private string _diretorio = DirectoryPathProvider.RelatoriosDirectory;
        private readonly ILogger _logger;

        public LocalFileWriter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<Result<string>> WriteAsync(byte[] toWrite, string nomeArquivo, CancellationToken ct = default, string extensao = null)
        {
            var caminhoCompleto = $"{_diretorio}/{nomeArquivo}";

            if (!string.IsNullOrWhiteSpace(extensao))
                caminhoCompleto += $".{extensao}";

            if(!Directory.Exists(_diretorio))
                Directory.CreateDirectory(_diretorio);

            try
            {
                await File.WriteAllBytesAsync(caminhoCompleto, toWrite, ct);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, $"{LogVariables.ClassAndMethodName} Ocorreu um erro ao salvar o arquivo. Caminho: {{Caminho}}",
                    nameof(LocalFileWriter), nameof(WriteAsync), caminhoCompleto);
                return Result.Fail("Erro ao salvar o arquivo.");
            }

            return caminhoCompleto;
        }
    }
}

using FluentResults;
using FluxoCaixa.Domain.Builder.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Lancamentos;
using FluxoCaixa.Infrastructure.Generic.Files;
using Newtonsoft.Json;
using System.Text;

namespace FluxoCaixa.Infrastructure.Generic.Builders.Relatorios
{
    public class JsonRelatorioBuilder : IRelatorioBuilder
    {
        protected readonly IFileWriter _fileWriter;
        protected Relatorio _relatorio;

        public JsonRelatorioBuilder(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void AdicionarLancamento(Lancamento lancamento)
        {
            if (_relatorio == null)
                throw new ArgumentNullException("O relatório precisa ser informado antes de adicionar lançamentos.");

            _relatorio.Caixa.AddLancamento(lancamento);
        }

        public Task<Result<string>> EscreverRelatorioAsync(CancellationToken ct = default)
        {
            if (_relatorio == null)
                throw new ArgumentNullException("O relatório precisa ser informado antes de finalizar o processo.");

            var json = JsonConvert.SerializeObject(_relatorio, Formatting.Indented);
            var bytes = Encoding.UTF8.GetBytes(json);

            return _fileWriter.WriteAsync(bytes, _relatorio.NomeArquivo, ct, "json");
        }

        public void SetRelatorio(Relatorio relatorio)
        {
            if (_relatorio != null)
                throw new ArgumentException("O relatório já foi informado.");

            if (relatorio.Caixa == null)
                throw new ArgumentNullException("O relatório precisa conter o caixa.");

            _relatorio = relatorio;
        }
    }
}

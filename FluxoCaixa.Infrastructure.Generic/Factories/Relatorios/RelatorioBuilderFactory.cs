using FluxoCaixa.Domain.Builder.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;
using FluxoCaixa.Domain.Factories.Relatorios.Builders;
using FluxoCaixa.Infrastructure.Generic.Builders.Relatorios;
using FluxoCaixa.Infrastructure.Generic.Files;

namespace FluxoCaixa.Infrastructure.Generic.Factories.Relatorios
{
    public class RelatorioBuilderFactory : IRelatorioBuilderFactory
    {
        private readonly IFileWriter _fileWriter;

        public RelatorioBuilderFactory(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public IRelatorioBuilder CriarBuilder(Relatorio relatorio)
        {
            switch(relatorio.Tipo)
            {
                case TipoRelatorio.JSON:
                    var builder = new JsonRelatorioBuilder(_fileWriter);
                    builder.SetRelatorio(relatorio);
                    return builder;
            }

            throw new NotImplementedException("Tipo de relatório não implementado.");
        }
    }
}

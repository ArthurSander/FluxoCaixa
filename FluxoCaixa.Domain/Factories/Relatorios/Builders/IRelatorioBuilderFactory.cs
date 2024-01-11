using FluxoCaixa.Domain.Builder.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;

namespace FluxoCaixa.Domain.Factories.Relatorios.Builders
{
    public interface IRelatorioBuilderFactory
    {
        IRelatorioBuilder CriarBuilder(Relatorio relatorio);
    }
}

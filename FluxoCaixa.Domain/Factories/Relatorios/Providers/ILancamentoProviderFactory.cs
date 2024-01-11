using FluxoCaixa.Domain.Builder.Relatorios;
using FluxoCaixa.Domain.Providers.Relatorios;

namespace FluxoCaixa.Domain.Factories.Relatorios.Providers
{
    public interface ILancamentoProviderFactory
    {
        ILancamentoProvider CriarProvider(IRelatorioBuilder relatorioBuilder);
    }
}

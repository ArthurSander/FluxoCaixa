using FluxoCaixa.Domain.Builder.Relatorios;
using FluxoCaixa.Domain.Providers.Relatorios;
using FluxoCaixa.Domain.Repositories.Relatorios;

namespace FluxoCaixa.Domain.Factories.Relatorios.Providers
{
    public class LancamentoProviderFactory : ILancamentoProviderFactory
    {
        private readonly IRelatorioReadRepository _repository;

        public LancamentoProviderFactory(IRelatorioReadRepository repository)
        { 
            _repository = repository;
        }

        public ILancamentoProvider CriarProvider(IRelatorioBuilder relatorioBuilder)
        {
            return new DefaultLancamentoProvider(relatorioBuilder, _repository);
        }
    }
}

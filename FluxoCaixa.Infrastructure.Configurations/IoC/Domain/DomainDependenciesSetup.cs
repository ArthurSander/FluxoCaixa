using FluxoCaixa.Domain.Factories.FluxoCaixa;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Services.FluxoCaixa;
using FluxoCaixa.Domain.Services.Relatorios;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure.Configurations.IoC.Domain
{
    public static class DomainDependenciesSetup
    {
        public static IServiceCollection SetupDomain(this IServiceCollection services)
        {
            services.SetupFluxoCaixaContext();
            services.SetupRelatoriosContext();

            return services;
        }

        private static void SetupFluxoCaixaContext(this IServiceCollection services)
        {
            services.AddScoped<IFluxoCaixaService, FluxoCaixaService>();
            services.AddScoped<ILancamentoFactory, DefaultLancamentoFactory>();
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioService, RelatorioService>();
        }
    }
}

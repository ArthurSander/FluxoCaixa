using FluxoCaixa.Application.Files;
using FluxoCaixa.Domain.Events;
using FluxoCaixa.Domain.Factories.Relatorios.Builders;
using FluxoCaixa.Infrastructure.Generic.Factories.Relatorios;
using FluxoCaixa.Infrastructure.Generic.Files;
using FluxoCaixa.Infrastructure.Generic.Publishers;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure.Configurations.IoC.Infrastructure
{
    public static class InfrastructureGenericsDependenciesSetup
    {
        public static IServiceCollection SetupInfrastructureGenerics(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.SetupRelatoriosContext();

            return services;
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioBuilderFactory, RelatorioBuilderFactory>();
            services.AddScoped<IFileWriter, LocalFileWriter>();
            services.AddScoped<IFileReader, LocalJsonFileReader>();
        }
    }
}

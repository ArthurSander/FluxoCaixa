using FluxoCaixa.Presentation.API.Mappers.FluxoCaixa;
using FluxoCaixa.Presentation.API.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Presentation.API.Mappers.Relatorios;
using FluxoCaixa.Presentation.API.Mappers.Relatorios.Interfaces;

namespace FluxoCaixa.Presentation.API.Setup.IoC
{
    public static class APIDependenciesSetup
    {
        public static IServiceCollection SetupAPI(this IServiceCollection services)
        {
            services.AddScoped<ICaixaPresentationMapper, CaixaPresentationMapper>();
            services.AddScoped<IRelatorioPresentationMapper, RelatorioPresentationMapper>();

            return services;
        }
    }
}

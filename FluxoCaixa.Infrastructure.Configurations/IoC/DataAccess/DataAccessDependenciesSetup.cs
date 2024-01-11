using FluxoCaixa.DataAccess.Contexts;
using FluxoCaixa.DataAccess.Mappers;
using FluxoCaixa.DataAccess.Mappers.FluxoCaixa;
using FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.DataAccess.Mappers.Relatorios;
using FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoCaixa.DataAccess.Models;
using FluxoCaixa.DataAccess.Repositories.FluxoCaixa;
using FluxoCaixa.DataAccess.Repositories.Relatorios;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Repositories.FluxoCaixa;
using FluxoCaixa.Domain.Repositories.Relatorios;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure.Configurations.IoC.DataAccess
{
    public static class DataAccessDependenciesSetup
    {
        public static IServiceCollection SetupDataAccess(this IServiceCollection services)
        {
            services.SetupFluxoCaixaContext();
            services.SetupRelatorioContext();

            return services;
        }

        private static void SetupFluxoCaixaContext(this IServiceCollection services)
        {
            services.AddScoped<FluxoCaixa.DataAccess.Mappers.FluxoCaixa.Interfaces.ICaixaDataMapper, FluxoCaixa.DataAccess.Mappers.FluxoCaixa.CaixaDataMapper>();
            services.AddScoped<IDefaultDataModelMapper<LancamentoDataModel, ILancamento>, LancamentoDataMapper>();
            services.AddScoped<IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento>, NovoLancamentoDataMapper>();

            services.AddScoped<ICaixaReadRepository, CaixaRepository>();
            services.AddScoped<ICaixaWriteRepository, CaixaRepository>();
        }

        private static void SetupRelatorioContext(this IServiceCollection services)
        {
            services.AddScoped<FluxoCaixa.DataAccess.Mappers.Relatorios.Interfaces.ICaixaDataMapper, FluxoCaixa.DataAccess.Mappers.Relatorios.CaixaDataMapper>();
            services.AddScoped<IRelatorioDataMapper, RelatorioDataMapper>();

            services.AddScoped<IRelatorioReadRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioWriteRepository, RelatorioRepository>();
        }
    }
}

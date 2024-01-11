using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Application.Mappers.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.Mappers.Relatorios;
using FluxoCaixa.Application.Mappers.Relatorios.Interfaces;
using FluxoCaixa.Application.Services.FluxoCaixa;
using FluxoCaixa.Application.Services.Relatorios;
using FluxoCaixa.Application.UseCases.FluxoCaixa;
using FluxoCaixa.Application.UseCases.FluxoCaixa.Interfaces;
using FluxoCaixa.Application.UseCases.Relatorios;
using FluxoCaixa.Application.UseCases.Relatorios.Interfaces;
using FluxoCaixa.Application.Validators;
using FluxoCaixa.Application.Validators.FluxoCaixa;
using FluxoCaixa.Application.Validators.Relatorios;
using FluxoCaixa.Domain.Factories.Relatorios.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure.Configurations.IoC.Application
{
    public static class ApplicationDependenciesSetup
    {
        public static IServiceCollection SetupApplication(this IServiceCollection services)
        {
            services.SetupFluxoCaixaContext();
            services.SetupRelatoriosContext();
            
            return services;
        }

        private static void SetupFluxoCaixaContext(this IServiceCollection services)
        {
            services.AddScoped<ICaixaApplicationMapper, CaixaApplicationMapper>();
            services.AddScoped<ILancamentoApplicationMapper, LancamentoApplicationMapper>();

            services.AddScoped<IFluxoCaixaApplicationService, FluxoCaixaApplicationService>();

            services.AddScoped<IAdicionarLancamentoUseCase, AdicionarLancamentoUseCase>();
            services.AddScoped<ICriarCaixaUseCase, CriarCaixaUseCase>();
            services.AddScoped<IConsultarSaldoUseCase, ConsultarSaldoUseCase>();

            services.AddScoped<IValidator<AdicionarLancamentoDto>, AdicionarLancamentoValidator>();
            services.AddScoped<IValidator<CriarCaixaDto>, CriarCaixaValidator>();
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioApplicationMapper, RelatorioApplicationMapper>();

            services.AddScoped<IRelatorioApplicationService, RelatorioApplicationService>();

            services.AddScoped<ICriarRelatorioUseCase, CriarRelatorioUseCase>();
            services.AddScoped<IDownloadRelatorioUseCase, DownloadRelatorioUseCase>();
            services.AddScoped<IConsultarStatusRelatorioUseCase, ConsultarStatusRelatorioUseCase>();

            services.AddScoped<IValidator<CriarRelatorioDto>, CriarRelatorioValidator>();

            services.AddScoped<ILancamentoProviderFactory, LancamentoProviderFactory>();

        }
    }
}

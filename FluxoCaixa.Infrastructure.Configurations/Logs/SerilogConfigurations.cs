using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FluxoCaixa.Infrastructure.Configurations.Logs
{
    public static class SerilogConfigurations
    {
        public static IServiceCollection ConfigureSerilog(this IServiceCollection services)
        {
            //Todo: adicionar sink para arquivos e ElasticSearch
            var logger = new LoggerConfiguration()
                .WriteTo.Logger(config =>
                config.WriteTo.Console())
                .CreateLogger();

            Log.Logger = logger;
            services.AddScoped<ILogger>(_ => logger);
            return services;
        }
    }
}

using FluxoCaixa.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.DataAccess.Contexts
{
    public static class FluxoCaixaDbContextSetup
    {
        public static IServiceCollection SetupDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<FluxoCaixaDbContext>(options =>
            {
                options.UseSqlServer(ConnectionStringProvider.FluxoCaixa);
                options.UseSnakeCaseNamingConvention();
            });

            return services;
        }

        public static void EnsureMigrationsApplied(this IServiceProvider sp)
        {
            using (var scope = sp.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<FluxoCaixaDbContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}

using FluxoCaixa.DataAccess.Configurations;
using FluxoCaixa.Shared.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;

namespace FluxoCaixa.DataAccess.Contexts
{
    public class FluxoCaixaDbContextFactory : IDesignTimeDbContextFactory<FluxoCaixaDbContext>
    {
        public FluxoCaixaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FluxoCaixaDbContext>();
            var connectionString = ConnectionStringProvider.FluxoCaixa;

            if (connectionString == null)
            {
                Log.Logger.Error($"{LogVariables.ClassAndMethodName} Não foi possível obter a ConnectionString do banco de dados.",
                    nameof(FluxoCaixaDbContextFactory), nameof(CreateDbContext));

                throw new ArgumentNullException("ConnectionString não informada.");
            }

            builder.UseSqlServer(connectionString);
            builder.UseSnakeCaseNamingConvention();

            return new FluxoCaixaDbContext(builder.Options);
        }
    }
}

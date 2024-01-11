using FluxoCaixa.Shared.Environments;

namespace FluxoCaixa.DataAccess.Configurations
{
    internal class ConnectionStringProvider
    {
        public static string FluxoCaixa =>
            Environment.GetEnvironmentVariable(EnvironmentVariables.DefaultDbConnectionString) ??
            "Server=127.0.0.1,1433;Database=FluxoCaixa;User Id=sa;Password=CashFlow@2024;TrustServerCertificate=True";
    }
}

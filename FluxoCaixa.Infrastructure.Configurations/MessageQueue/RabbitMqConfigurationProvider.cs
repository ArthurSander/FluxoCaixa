using FluxoCaixa.Shared.Environments;

namespace FluxoCaixa.Infrastructure.Configurations.MessageQueue
{
    public static class RabbitMqConfigurationProvider
    {
        public static string HostName = Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqHostName) ?? "localhost";
        public static string User = Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqUser) ?? "admin";
        public static string Password = Environment.GetEnvironmentVariable(EnvironmentVariables.RabbitMqPassword) ?? "CashFlow@2024";
    }
}

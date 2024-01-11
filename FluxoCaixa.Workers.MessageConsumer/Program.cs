using Microsoft.Extensions.Hosting;
using FluxoCaixa.Infrastructure.Configurations.MessageQueue;
using FluxoCaixa.Infrastructure.Configurations.Logs;
using FluxoCaixa.Infrastructure.Configurations.IoC.Domain;
using FluxoCaixa.Infrastructure.Configurations.IoC.Application;
using FluxoCaixa.Infrastructure.Configurations.IoC.DataAccess;
using FluxoCaixa.DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;
using FluxoCaixa.Workers.MessageConsumer;
using FluxoCaixa.Infrastructure.Generic.Process;
using FluxoCaixa.Infrastructure.Configurations.IoC.Infrastructure;

var hostBuilder = Host.CreateDefaultBuilder();

hostBuilder.ConfigureServices(services =>
{
    services.ConfigureRabbitMq(RabbitMqConfigurationType.Consumer)
        .ConfigureSerilog()
        .SetupDomain()
        .SetupApplication()
        .SetupDataAccess()
        .SetupDataAccess()
        .SetupDbContexts()
        .SetupInfrastructureGenerics();


    services.AddSingleton<CancellationTokenProvider>();
    services.AddSingleton<ICancellationTokenProvider, CancellationTokenProvider>();

    services.AddHostedService<Worker>();
});

var host = hostBuilder.Build();

host.Services.EnsureMigrationsApplied();

await host.RunAsync();
using FluxoCaixa.Presentation.API.Setup.IoC;
using FluxoCaixa.Infrastructure.Configurations.IoC.Application;
using FluxoCaixa.Infrastructure.Configurations.IoC.Domain;
using FluxoCaixa.Infrastructure.Configurations.IoC.DataAccess;
using FluxoCaixa.Infrastructure.Configurations.Logs;
using FluxoCaixa.Infrastructure.Configurations.IoC.Infrastructure;
using FluxoCaixa.DataAccess.Contexts;
using FluxoCaixa.Infrastructure.Configurations.MessageQueue;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.SetupAPI()
    .SetupApplication()
    .SetupDomain()
    .SetupDataAccess()
    .SetupInfrastructureGenerics();

builder.Services.ConfigureRabbitMq(RabbitMqConfigurationType.Publisher);

builder.Services.SetupDbContexts();

builder.Services.ConfigureSerilog();

var app = builder.Build();

app.Services.EnsureMigrationsApplied();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

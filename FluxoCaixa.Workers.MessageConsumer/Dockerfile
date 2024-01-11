FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluxoCaixa.Workers.MessageConsumer/FluxoCaixa.Workers.MessageConsumer.csproj", "FluxoCaixa.Workers.MessageConsumer/"]
COPY ["FluxoCaixa.Application/FluxoCaixa.Application.csproj", "FluxoCaixa.Application/"]
COPY ["FluxoCaixa.Domain/FluxoCaixa.Domain.csproj", "FluxoCaixa.Domain/"]
COPY ["FluxoCaixa.Shared/FluxoCaixa.Shared.csproj", "FluxoCaixa.Shared/"]
COPY ["FluxoCaixa.Infrastructure.Configurations/FluxoCaixa.Infrastructure.Configurations.csproj", "FluxoCaixa.Infrastructure.Configurations/"]
COPY ["FluxoCaixa.DataAccess/FluxoCaixa.DataAccess.csproj", "FluxoCaixa.DataAccess/"]
COPY ["FluxoCaixa.Infrastructure.Generic/FluxoCaixa.Infrastructure.Generic.csproj", "FluxoCaixa.Infrastructure.Generic/"]
RUN dotnet restore "./FluxoCaixa.Workers.MessageConsumer/./FluxoCaixa.Workers.MessageConsumer.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa.Workers.MessageConsumer"
RUN dotnet build "./FluxoCaixa.Workers.MessageConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FluxoCaixa.Workers.MessageConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir /app/relatorios
RUN chmod 775 -R /app/relatorios
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.Workers.MessageConsumer.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluxoCaixa.Presentation.API/FluxoCaixa.Presentation.API.csproj", "FluxoCaixa.Presentation.API/"]
COPY ["FluxoCaixa.Application/FluxoCaixa.Application.csproj", "FluxoCaixa.Application/"]
COPY ["FluxoCaixa.Domain/FluxoCaixa.Domain.csproj", "FluxoCaixa.Domain/"]
COPY ["FluxoCaixa.Shared/FluxoCaixa.Shared.csproj", "FluxoCaixa.Shared/"]
COPY ["FluxoCaixa.Infrastructure.Configurations/FluxoCaixa.Infrastructure.Configurations.csproj", "FluxoCaixa.Infrastructure.Configurations/"]
COPY ["FluxoCaixa.DataAccess/FluxoCaixa.DataAccess.csproj", "FluxoCaixa.DataAccess/"]
COPY ["FluxoCaixa.Infrastructure.Generic/FluxoCaixa.Infrastructure.Generic.csproj", "FluxoCaixa.Infrastructure.Generic/"]
RUN dotnet restore "./FluxoCaixa.Presentation.API/./FluxoCaixa.Presentation.API.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa.Presentation.API"
RUN dotnet build "./FluxoCaixa.Presentation.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FluxoCaixa.Presentation.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.Presentation.API.dll"]
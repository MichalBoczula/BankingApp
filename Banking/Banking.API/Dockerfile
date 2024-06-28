
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Banking/Banking.API/Banking.API.csproj", "Banking/Banking.API/"]
COPY ["Banking/Banking.Application/Banking.Application.csproj", "Banking/Banking.Application/"]
COPY ["Banking/Banking.Persistance/Banking.Persistance.csproj", "Banking/Banking.Persistance/"]
COPY ["Banking/Banking.Domain/Banking.Domain.csproj", "Banking/Banking.Domain/"]
COPY ["Banking/BankingApp.DataTransferObject/BankingApp.DataTransferObject.csproj", "Banking/BankingApp.DataTransferObject/"]
COPY ["Banking/Banking.infrastructure/Banking.infrastructure.csproj", "Banking/Banking.infrastructure/"]
RUN dotnet restore "./Banking/Banking.API/Banking.API.csproj"
COPY . .
WORKDIR "/src/Banking/Banking.API"
RUN dotnet build "./Banking.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Banking.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.API.dll"]
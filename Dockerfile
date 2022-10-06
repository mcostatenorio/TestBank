FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["/src", "./"]

RUN dotnet restore "./MS-Financeiro/MS-Financeiro.csproj"
COPY . .
RUN dotnet build "./MS-Financeiro/MS-Financeiro.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./MS-Financeiro/MS-Financeiro.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MS-Financeiro.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TiendaServicios.Api.Login/TiendaServicios.Api.Login.csproj", "TiendaServicios.Api.Login/"]
RUN dotnet restore "TiendaServicios.Api.Login/TiendaServicios.Api.Login.csproj"
COPY . .
WORKDIR "/src/TiendaServicios.Api.Login"
RUN dotnet build "TiendaServicios.Api.Login.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaServicios.Api.Login.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicios.Api.Login.dll"]
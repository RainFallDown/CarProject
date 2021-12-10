#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarProject.Api/CarProject.Api.csproj", "CarProject.Api/"]
COPY ["CarProject.Infrastructure/CarProject.Infrastructure.csproj", "CarProject.Infrastructure/"]
COPY ["CarProject.Core/CarProject.Core.csproj", "CarProject.Core/"]
RUN dotnet restore "CarProject.Api/CarProject.Api.csproj"
COPY . .
WORKDIR "/src/CarProject.Api"
RUN dotnet build "CarProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarProject.Api.dll"]
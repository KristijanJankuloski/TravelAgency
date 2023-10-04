#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TravelAgency/TravelAgency.csproj", "TravelAgency/"]
COPY ["TravelAgency.Domain/TravelAgency.Domain.csproj", "TravelAgency.Domain/"]
COPY ["TravelAgency.DTOs/TravelAgency.DTOs.csproj", "TravelAgency.DTOs/"]
COPY ["TravelAgency.Helpers/TravelAgency.Helpers.csproj", "TravelAgency.Helpers/"]
COPY ["TravelAgency.DataAccess/TravelAgency.DataAccess.csproj", "TravelAgency.DataAccess/"]
COPY ["TravelAgency.Services/TravelAgency.Services.csproj", "TravelAgency.Services/"]
COPY ["TravelAgency.Mappers/TravelAgency.Mappers.csproj", "TravelAgency.Mappers/"]
RUN dotnet restore "TravelAgency/TravelAgency.csproj"
COPY . .
WORKDIR "/src/TravelAgency"
RUN dotnet build "TravelAgency.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelAgency.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelAgency.dll"]
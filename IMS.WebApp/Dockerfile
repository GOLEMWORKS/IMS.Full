#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IMS.WebApp/IMS.WebApp.csproj", "IMS.WebApp/"]
COPY ["IMS.Plugins.EFCore/IMS.Plugins.EFCore.csproj", "IMS.Plugins.EFCore/"]
COPY ["IMS.CoreBusiness/IMS.CoreBusiness.csproj", "IMS.CoreBusiness/"]
COPY ["IMS.UseCases/IMS.UseCases.csproj", "IMS.UseCases/"]
RUN dotnet restore "IMS.WebApp/IMS.WebApp.csproj"
COPY . .
WORKDIR "/src/IMS.WebApp"
RUN dotnet build "IMS.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IMS.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMS.WebApp.dll"]
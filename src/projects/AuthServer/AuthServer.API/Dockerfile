FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80
COPY src/corePackages/Core.CrossCuttingConcerns/*.csproj src/corePackages/Core.CrossCuttingConcerns/
COPY src/corePackages/Core.Security/*.csproj src/corePackages/Core.Security/
COPY src/corePackages/Core.Shared/*.csproj src/corePackages/Core.Shared/
COPY src/projects/AuthServer/AuthServer.API/*.csproj src/projects/AuthServer/AuthServer.API/

RUN dotnet restore src/projects/AuthServer/AuthServer.API/*.csproj
COPY . .
RUN dotnet publish src/projects/AuthServer/AuthServer.API/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","AuthServer.API.dll"]

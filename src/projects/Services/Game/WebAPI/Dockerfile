FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80

COPY src/corePackages/Core.Security/*.csproj src/corePackages/Core.Security/
COPY src/corePackages/Core.Shared/*.csproj src/corePackages/Core.Shared/
COPY src/projects/Services/Game/Persistance/*.csproj src/projects/Services/Game/Persistance/
COPY src/projects/Services/Game/WebAPI/*.csproj src/projects/Services/Game/WebAPI/

RUN dotnet restore src/projects/Services/Game/WebAPI/*.csproj
COPY . .
RUN dotnet publish src/projects/Services/Game/WebAPI/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","WebAPI.dll"]

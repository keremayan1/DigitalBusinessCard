FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80


COPY src/corePackages/Core.Shared/*.csproj src/corePackages/Core.Shared/
COPY src/corePackages/Core.Application/*.csproj src/corePackages/Core.Application/
COPY src/corePackages/Core.Persistance/*.csproj src/corePackages/Core.Persistance/
COPY src/projects/Services/IBANAccount/IBANAccount.API/*.csproj src/projects/Services/IBANAccount/IBANAccount.API/

RUN dotnet restore src/projects/Services/IBANAccount/IBANAccount.API/*.csproj
COPY . .
RUN dotnet publish src/projects/Services/IBANAccount/IBANAccount.API/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","IBANAccount.API.dll"]

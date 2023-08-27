FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80


COPY src/corePackages/Core.Shared/*.csproj src/corePackages/Core.Shared/
COPY src/corePackages/Core.Persistance/*.csproj src/corePackages/Core.Persistance/
COPY src/corePackages/Core.Application/*.csproj src/corePackages/Core.Application/
COPY src/projects/Services/CyrptoAccount/WebAPI/*.csproj src/projects/Services/CyrptoAccount/WebAPI/

RUN dotnet restore src/projects/Services/CyrptoAccount/WebAPI/*.csproj
COPY . .
RUN dotnet publish src/projects/Services/CyrptoAccount/WebAPI/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","WebAPI.dll"]

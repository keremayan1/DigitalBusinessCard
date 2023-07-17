FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80

COPY src/corePackages/Core.Security/*.csproj src/corePackages/Core.Security/
COPY src/corePackages/Core.Shared/*.csproj src/corePackages/Core.Shared/
COPY src/projects/Services/SocialMedia/Application/*.csproj src/projects/Services/SocialMedia/Application/
COPY src/projects/Services/SocialMedia/Persistance/*.csproj src/projects/Services/SocialMedia/Persistance/
COPY src/projects/Services/SocialMedia/WebAPI/*.csproj src/projects/Services/SocialMedia/WebAPI/

RUN dotnet restore src/projects/Services/SocialMedia/WebAPI/*.csproj
COPY . .
RUN dotnet publish src/projects/Services/SocialMedia/WebAPI/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","WebAPI.dll"]

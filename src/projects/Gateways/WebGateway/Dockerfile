FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /app
EXPOSE 80

COPY src/projects/Gateways/WebGateway/*.csproj src/projects/Gateways/WebGateway/

RUN dotnet restore src/projects/Gateways/WebGateway/*.csproj
COPY . .
RUN dotnet publish src/projects/Gateways/WebGateway/*.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime

WORKDIR /app
COPY --from=build /app/out . 

ENTRYPOINT ["dotnet","WebGateway.dll"]

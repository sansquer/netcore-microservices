FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CloudAppCore1.sln ./
COPY CloudAppCore1/CloudAppCore1.csproj CloudAppCore1/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/CloudAppCore1
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CloudAppCore1.dll"]

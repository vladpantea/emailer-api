FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY Emailer.API.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_EmailDatabaseSettings__ConnectionString="someconnectionstring"
ENV ASPNETCORE_EmailDatabaseSettings__EmailCollectionName="somecollection"
ENV ASPNETCORE_EmailDatabaseSettings__DatabaseName="somedb"
ENV ASPNETCORE_ApplicationSettings__Port="80"
ENV ASPNETCORE_ApplicationSettings__ServiceAudience="someaudience"
ENV ASPNETCORE_ApplicationSettings__IdentityIssuer="someidentity"
ENV ASPNETCORE_ApplicationSettings__Secret="somesecret"

COPY --from=build /app .
ENTRYPOINT ["dotnet", "Emailer.API.dll"]
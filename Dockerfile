FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY Emailer.API.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
#demo env variables
#ENV ASPNETCORE_ENVIRONMENT="Development"
#ENV ASPNETCORE_EmailDatabaseSettings__ConnectionString="someconnectionstring"

COPY --from=build /app .
ENTRYPOINT ["dotnet", "Emailer.API.dll"]
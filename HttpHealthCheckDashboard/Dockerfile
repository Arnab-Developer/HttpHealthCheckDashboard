FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY HttpHealthCheckDashboard/bin/publish ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "HttpHealthCheckDashboard.dll"]
FROM mcr.microsoft.com/dotnet/runtime:5.0
COPY publish/ ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "HttpHealthCheckDashboard.dll"]
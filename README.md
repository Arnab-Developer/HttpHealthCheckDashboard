# HTTP health check web dashboard

[![CI CD](https://github.com/Arnab-Developer/HttpHealthCheckDashboard/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/Arnab-Developer/HttpHealthCheckDashboard/actions/workflows/ci-cd.yml)
![Docker Image Version (latest by date)](https://img.shields.io/docker/v/45862391/httphealthcheckdashboard?label=docker)

This is a dashboard to show health check results of your favorite http web apps.

![image](https://user-images.githubusercontent.com/3396447/117486658-8747af80-af87-11eb-883f-da6f8a4532cf.png)

## Docker image

This app has been hosted in 
[docker hub](https://hub.docker.com/r/45862391/httphealthcheckdashboard) in a 
container image.

## How to extend this app

This app is checking health of some URIs, you can find them in `appsettings.json`
and `appsettings.Development.json` file. If you want to check your own URI as well
in this app then do the following changes.

- Add a new section in `appsettings.json` under `ApiDetails`

```
"ApiDetails": [
  {
    "Name": "[name of the URI]",
    "Url": "[URI]",
    "Credential": {
      "UserName": "[user name if any]",
      "Password": "[password if any]"
    },
    "IsEnable": true
  }
]
```

- Add a new section in `appsettings.json` under `HealthChecks-UI` -> `HealthChecks`

```
"HealthChecks-UI": {
  "HealthChecks": [
    {
      "Name": "[name of health check]",
      "Uri": "[health check URI]"
    }
  ]
}
```

- Create a new class inside `HttpHealthCheckDashboard` -> `HealthChecks` which
inherits `BaseHealthCheck`

```
public class [ClassName]HealthCheck : BaseHealthCheck
{
    public [ClassName]HealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
        : base(urlDetails, commonHealthCheck)
    {
    }
}
```

- Add the class into `HttpHealthCheckDashboard.HealthCheckExtensions.AddHealthChecksUrls(this IServiceCollection services)`

```
public static IHealthChecksBuilder AddHealthChecksUrls(this IServiceCollection services) =>
    services
        .AddHealthChecks()
        .AddCheck<[ClassName]HealthCheck>("[ClassName]");
```

- Add endpoint mapping in `HttpHealthCheckDashboard.HealthCheckExtensions.MapHealthChecksUrls(this IEndpointRouteBuilder endpoints)`

```
public static void MapHealthChecksUrls(this IEndpointRouteBuilder endpoints)
{
    endpoints.MapHealthChecks("/[classname]-hc", new HealthCheckOptions()
    {
        Predicate = r => r.Name.Contains("[ClassName]"),
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
}
```

- Open your bowser and navigate to `http://localhost:[your-machine-port]/hc-ui` and you 
should see your new URI in the health check app.

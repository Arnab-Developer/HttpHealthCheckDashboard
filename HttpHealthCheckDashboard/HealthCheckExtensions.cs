using HealthChecks.UI.Client;
using HttpHealthCheckDashboard.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace HttpHealthCheckDashboard
{
    public static class HealthCheckExtensions
    {
        public static IHealthChecksBuilder AddHealthChecksUrls(this IServiceCollection services) =>
            services
                .AddHealthChecks()
                .AddCheck<MicrosoftHealthCheck>("Microsoft")
                .AddCheck<GoogleHealthCheck>("Google")
                .AddCheck<InactiveUrlHealthCheck>("InactiveUrl")
                .AddCheck<InvalidUrlHealthCheck>("InvalidUrl");

        public static void MapHealthChecksUrls(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/microsoft-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Microsoft"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/google-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("Google"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/inactiveurl-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("InactiveUrl"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/invalidurl-hc", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("InvalidUrl"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}

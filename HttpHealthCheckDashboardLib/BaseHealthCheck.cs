using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HttpHealthCheckDashboardLib
{
    public abstract class BaseHealthCheck
        : Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck
    {
        private readonly IEnumerable<ApiDetail> _urlDetails;
        private readonly ArnabDeveloper.HttpHealthCheck.IHealthCheck _healthCheck;

        public BaseHealthCheck(IEnumerable<ApiDetail> urlDetails, 
            ArnabDeveloper.HttpHealthCheck.IHealthCheck healthCheck)
        {
            _urlDetails = urlDetails;
            _healthCheck = healthCheck;
        }

        Task<HealthCheckResult> Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken)
        {
            string apiNameToTest = GetType().Name.Substring(0, GetType().Name.IndexOf("HealthCheck"));
            ApiDetail? apiDetail = _urlDetails.FirstOrDefault(u => u.Name == apiNameToTest && u.IsEnable);

            if (apiDetail == null)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
            try
            {
                bool isApiHealthy = false;
                if (apiDetail.ApiCredential is null ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.UserName) ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.Password))
                {
                    isApiHealthy = _healthCheck.IsHealthy(apiDetail.Url);
                }
                else
                {
                    isApiHealthy = _healthCheck.IsHealthy(apiDetail.Url, apiDetail.ApiCredential);
                }
                return isApiHealthy
                    ? Task.FromResult(HealthCheckResult.Healthy())
                    : Task.FromResult(HealthCheckResult.Unhealthy());
            }
            catch
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }            
        }
    }
}

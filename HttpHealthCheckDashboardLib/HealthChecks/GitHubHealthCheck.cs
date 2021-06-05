using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class GitHubHealthCheck : BaseHealthCheck
    {
        public GitHubHealthCheck(IEnumerable<ApiDetail> urlDetails, IHealthCheck healthCheck)
            : base(urlDetails, healthCheck)
        {
        }
    }
}

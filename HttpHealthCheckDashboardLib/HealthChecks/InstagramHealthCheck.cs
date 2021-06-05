using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class InstagramHealthCheck : BaseHealthCheck
    {
        public InstagramHealthCheck(IEnumerable<ApiDetail> urlDetails, IHealthCheck healthCheck)
            : base(urlDetails, healthCheck)
        {
        }
    }
}

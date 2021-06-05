using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class TwitterHealthCheck : BaseHealthCheck
    {
        public TwitterHealthCheck(IEnumerable<ApiDetail> urlDetails, IHealthCheck healthCheck)
            : base(urlDetails, healthCheck)
        {
        }
    }
}

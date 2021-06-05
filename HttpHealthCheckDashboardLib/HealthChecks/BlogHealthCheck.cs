using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class BlogHealthCheck : BaseHealthCheck
    {
        public BlogHealthCheck(IEnumerable<ApiDetail> urlDetails, IHealthCheck healthCheck)
            : base(urlDetails, healthCheck)
        {
        }
    }
}

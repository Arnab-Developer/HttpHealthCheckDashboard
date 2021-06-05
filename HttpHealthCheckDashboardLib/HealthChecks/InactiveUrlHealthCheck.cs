using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class InactiveUrlHealthCheck : BaseHealthCheck
    {
        public InactiveUrlHealthCheck(IEnumerable<ApiDetail> urlDetails, IHealthCheck healthCheck)
            : base(urlDetails, healthCheck)
        {
        }
    }
}

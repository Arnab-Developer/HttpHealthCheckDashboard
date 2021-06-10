using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class InactiveUrlHealthCheck : BaseHealthCheck
    {
        public InactiveUrlHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck,
            IApiDetailFinder apiDetailFinder)
            : base(urlDetails, commonHealthCheck, apiDetailFinder)
        {
        }
    }
}

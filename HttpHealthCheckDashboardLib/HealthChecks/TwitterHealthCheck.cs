using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class TwitterHealthCheck : BaseHealthCheck
    {
        public TwitterHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

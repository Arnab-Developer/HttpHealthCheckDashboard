using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class BlogHealthCheck : BaseHealthCheck
    {
        public BlogHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck,
            IApiDetailFinder apiDetailFinder)
            : base(urlDetails, commonHealthCheck, apiDetailFinder)
        {
        }
    }
}

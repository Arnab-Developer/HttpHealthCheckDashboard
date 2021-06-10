using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib.HealthChecks
{
    public class GitHubHealthCheck : BaseHealthCheck
    {
        public GitHubHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck,
            IApiDetailFinder apiDetailFinder)
            : base(urlDetails, commonHealthCheck, apiDetailFinder)
        {
        }
    }
}

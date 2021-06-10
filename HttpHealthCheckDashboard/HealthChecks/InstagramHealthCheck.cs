using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboard
{
    public class InstagramHealthCheck : BaseHealthCheck
    {
        public InstagramHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

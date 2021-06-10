using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboard
{
    public class TwitterHealthCheck : BaseHealthCheck
    {
        public TwitterHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

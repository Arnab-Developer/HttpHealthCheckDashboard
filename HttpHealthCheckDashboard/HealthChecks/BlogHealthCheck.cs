using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboard
{
    public class BlogHealthCheck : BaseHealthCheck
    {
        public BlogHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

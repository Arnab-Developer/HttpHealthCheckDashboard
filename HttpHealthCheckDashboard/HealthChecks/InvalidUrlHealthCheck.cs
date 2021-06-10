using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;
using System.Collections.Generic;

namespace HttpHealthCheckDashboard
{
    public class InvalidUrlHealthCheck : BaseHealthCheck
    {
        public InvalidUrlHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

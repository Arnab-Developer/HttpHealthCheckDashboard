using ArnabDeveloper.HttpHealthCheck;
using HttpHealthCheckDashboardLib;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLibTests
{
    public class TestHealthCheck : BaseHealthCheck
    {
        public TestHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

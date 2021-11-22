using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;

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

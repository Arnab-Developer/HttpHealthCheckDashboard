using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;

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

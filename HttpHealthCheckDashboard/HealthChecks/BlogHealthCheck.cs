using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;

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

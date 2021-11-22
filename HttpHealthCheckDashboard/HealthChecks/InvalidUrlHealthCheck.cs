using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;

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

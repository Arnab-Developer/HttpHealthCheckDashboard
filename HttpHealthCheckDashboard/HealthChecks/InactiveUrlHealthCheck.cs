using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;

namespace HttpHealthCheckDashboard
{
    public class InactiveUrlHealthCheck : BaseHealthCheck
    {
        public InactiveUrlHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }
    }
}

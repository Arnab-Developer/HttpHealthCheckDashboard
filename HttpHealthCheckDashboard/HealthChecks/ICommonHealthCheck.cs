using ArnabDeveloper.HttpHealthCheck;

namespace HttpHealthCheckDashboard.HealthChecks
{
    public interface ICommonHealthCheck
    {
        bool IsApiHealthy(ApiDetail? apiDetail);
    }
}

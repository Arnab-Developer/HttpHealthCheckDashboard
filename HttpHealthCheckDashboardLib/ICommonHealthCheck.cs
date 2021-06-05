using ArnabDeveloper.HttpHealthCheck;

namespace HttpHealthCheckDashboardLib
{
    public interface ICommonHealthCheck
    {
        bool IsApiHealthy(ApiDetail? apiDetail);
    }
}

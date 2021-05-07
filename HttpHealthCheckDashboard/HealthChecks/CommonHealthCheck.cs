using ArnabDeveloper.HttpHealthCheck;

namespace HttpHealthCheckDashboard.HealthChecks
{
    internal class CommonHealthCheck : ICommonHealthCheck
    {
        private readonly IHealthCheck _healthCheck;

        public CommonHealthCheck(IHealthCheck healthCheck)
        {
            _healthCheck = healthCheck;
        }

        bool ICommonHealthCheck.IsApiHealthy(ApiDetail? apiDetail)
        {
            if (apiDetail == null)
            {
                return false;
            }
            try
            {
                bool isApiHealthy = false;
                if (apiDetail.ApiCredential is null ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.UserName) ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.Password))
                {
                    isApiHealthy = _healthCheck.IsHealthy(apiDetail.Url);
                }
                else
                {
                    isApiHealthy = _healthCheck.IsHealthy(apiDetail.Url, apiDetail.ApiCredential);
                }
                return isApiHealthy;
            }
            catch
            {
                return false;
            }
        }
    }
}

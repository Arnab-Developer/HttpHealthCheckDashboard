using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HttpHealthCheckDashboardLib
{
    public abstract class BaseHealthCheck
        : Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck
    {
        private readonly IEnumerable<ApiDetail> _urlDetails;
        private readonly ICommonHealthCheck _commonHealthCheck;
        private readonly IApiDetailFinder _apiDetailFinder;

        public BaseHealthCheck(IEnumerable<ApiDetail> urlDetails,
            ICommonHealthCheck commonHealthCheck, IApiDetailFinder apiDetailFinder)
        {
            _urlDetails = urlDetails;
            _commonHealthCheck = commonHealthCheck;
            _apiDetailFinder = apiDetailFinder;
        }

        Task<HealthCheckResult> Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken)
        {
            Predicate<ApiDetail> match = GetMatch();
            ApiDetail? apiDetail = _apiDetailFinder.FindApiDetail(_urlDetails, match);

            return _commonHealthCheck.IsApiHealthy(apiDetail)
                ? Task.FromResult(HealthCheckResult.Healthy())
                : Task.FromResult(HealthCheckResult.Unhealthy());
        }

        protected virtual Predicate<ApiDetail> GetMatch()
        {
            int indexOfHealthCheck = GetType().Name.IndexOf("HealthCheck");
            string apiNameToTest = GetType().Name.Substring(0, indexOfHealthCheck);
            return new Predicate<ApiDetail>(u => u.Name == apiNameToTest && u.IsEnable);
        }
    }
}

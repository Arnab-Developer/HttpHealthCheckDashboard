﻿using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HttpHealthCheckDashboardLib
{
    public abstract class BaseHealthCheck
        : Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck
    {
        private readonly IEnumerable<ApiDetail> _urlDetails;
        private readonly ICommonHealthCheck _commonHealthCheck;

        public BaseHealthCheck(IEnumerable<ApiDetail> urlDetails,
            ICommonHealthCheck commonHealthCheck)
        {
            _urlDetails = urlDetails;
            _commonHealthCheck = commonHealthCheck;
        }

        Task<HealthCheckResult> Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken)
        {
            string apiNameToTest = GetType().Name.Substring(0, GetType().Name.IndexOf("HealthCheck"));
            ApiDetail? apiDetail = _urlDetails.ToList().Find(u => u.Name == apiNameToTest && u.IsEnable);

            return _commonHealthCheck.IsApiHealthy(apiDetail)
                ? Task.FromResult(HealthCheckResult.Healthy())
                : Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}

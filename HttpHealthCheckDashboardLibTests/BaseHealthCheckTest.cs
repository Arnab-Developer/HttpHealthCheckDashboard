using ArnabDeveloper.HttpHealthCheck;
using HttpHealthCheckDashboardLib;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace HttpHealthCheckDashboardLibTests
{
    public class BaseHealthCheckTest
    {
        private readonly IEnumerable<ApiDetail> _urlDetails;
        private readonly Mock<ICommonHealthCheck> _commonHealthCheckMock;
        private readonly Mock<BaseHealthCheck> _baseHealthCheckMock;
        private Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck? _healthCheck;

        public BaseHealthCheckTest()
        {
            _urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Base", "url3", new ApiCredential("user3", "pass3"), true),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };
            _commonHealthCheckMock = new Mock<ICommonHealthCheck>();
            _baseHealthCheckMock = new Mock<BaseHealthCheck>(_urlDetails, _commonHealthCheckMock.Object);
        }

        [Fact]
        public void Can_CheckHealth_ReturnHealthy()
        {
            _commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(_urlDetails.ElementAt(2)))
                .Returns(true);

            _healthCheck = _baseHealthCheckMock.Object;

            HealthCheckResult healthCheckResult = _healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Healthy(), healthCheckResult);
        }

        [Fact]
        public void Can_CheckHealth_ReturnUnHealthy()
        {
            _commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(_urlDetails.ElementAt(2)))
                .Returns(false);

            _healthCheck = _baseHealthCheckMock.Object;

            HealthCheckResult healthCheckResult = _healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Unhealthy(), healthCheckResult);
        }
    }
}

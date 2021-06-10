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
        [Fact]
        public void Can_CheckHealth_ReturnHealthy()
        {
            IEnumerable<ApiDetail> urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Test", "url3", new ApiCredential("user3", "pass3"), true),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };

            Mock<ICommonHealthCheck> commonHealthCheckMock = new();
            Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck healthCheck
                = new TestHealthCheck(urlDetails, commonHealthCheckMock.Object);

            commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(urlDetails.ElementAt(2)))
                .Returns(true);

            HealthCheckResult healthCheckResult = healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Healthy(), healthCheckResult);
        }

        [Fact]
        public void Can_CheckHealth_ReturnUnHealthy()
        {
            IEnumerable<ApiDetail> urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Test", "url3", new ApiCredential("user3", "pass3"), true),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };

            Mock<ICommonHealthCheck> commonHealthCheckMock = new();
            Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck healthCheck
                = new TestHealthCheck(urlDetails, commonHealthCheckMock.Object);

            commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(urlDetails.ElementAt(2)))
                .Returns(false);

            HealthCheckResult healthCheckResult = healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Unhealthy(), healthCheckResult);
        }

        [Fact]
        public void Can_CheckHealth_ReturnUnHealthyIfIsEnableFalse()
        {
            IEnumerable<ApiDetail> urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Test", "url3", new ApiCredential("user3", "pass3"), false),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };

            Mock<ICommonHealthCheck> commonHealthCheckMock = new();
            Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck healthCheck
                = new TestHealthCheck(urlDetails, commonHealthCheckMock.Object);

            commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(null))
                .Returns(false);

            HealthCheckResult healthCheckResult = healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Unhealthy(), healthCheckResult);
        }

        [Fact]
        public void Can_CheckHealth_ReturnUnHealthyIfInvalidMatch()
        {
            IEnumerable<ApiDetail> urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Test", "url3", new ApiCredential("user3", "pass3"), false),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };

            Mock<ICommonHealthCheck> commonHealthCheckMock = new();
            Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck healthCheck
                = new TestCustomMatchHealthCheck(urlDetails, commonHealthCheckMock.Object);

            commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(null))
                .Returns(false);

            HealthCheckResult healthCheckResult = healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Unhealthy(), healthCheckResult);
        }

        /*[Fact]
        public void Can_GetMatch_ReturnCorrectMatch()
        {
            IEnumerable<ApiDetail> urlDetails = new List<ApiDetail>()
            {
                new ApiDetail("api1", "url1", new ApiCredential("user1", "pass1"), true),
                new ApiDetail("api2", "url2", new ApiCredential("user2", "pass2"), true),
                new ApiDetail("Test", "url3", new ApiCredential("user3", "pass3"), true),
                new ApiDetail("api4", "url4", new ApiCredential("user4", "pass4"), true)
            };

            Mock<ICommonHealthCheck> commonHealthCheckMock = new();
            Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck healthCheck 
                = new TestHealthCheck(urlDetails, commonHealthCheckMock.Object);

            commonHealthCheckMock
                .Setup(s => s.IsApiHealthy(urlDetails.ElementAt(2)))
                .Returns(true);

            HealthCheckResult healthCheckResult = healthCheck.CheckHealthAsync(
                new HealthCheckContext(), new CancellationToken()).Result;

            Assert.Equal(HealthCheckResult.Healthy(), healthCheckResult);
        }*/
    }
}

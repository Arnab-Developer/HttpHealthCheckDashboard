using ArnabDeveloper.HttpHealthCheck;
using HttpHealthCheckDashboardLib;
using Moq;
using Xunit;
using System;

namespace HttpHealthCheckDashboardLibTests
{
    public class CommonHealthCheckTest
    {
        private readonly Mock<IHealthCheck> _healthCheckMock;
        private readonly ICommonHealthCheck _commonHealthCheck;

        public CommonHealthCheckTest()
        {
            _healthCheckMock = new Mock<IHealthCheck>();
            _commonHealthCheck = new CommonHealthCheck(_healthCheckMock.Object);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnTrueForOnlyUrl()
        {
            ApiDetail apiDetail = new("demo name", "demo url", null, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(true);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.True(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnTrueForUrlWithCredential()
        {
            ApiCredential apiCredential = new("demo user", "demo pass");
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, apiCredential))
                .Returns(true);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.True(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForOnlyUrl()
        {
            ApiDetail apiDetail = new("demo name", "demo url", null, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(false);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.False(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForUrlWithCredential()
        {
            ApiCredential apiCredential = new("demo user", "demo pass");
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, apiCredential))
                .Returns(false);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.False(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForNullApiDetail()
        {
            ApiDetail apiDetail = new("demo name", "demo url", null, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(true);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(null);

            Assert.False(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForException()
        {
            ApiDetail apiDetail = new("demo name", "demo url", null, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Throws<NullReferenceException>();

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.False(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnTrueForUrlWithEmptyCredential()
        {
            ApiCredential apiCredential = new(string.Empty, string.Empty);
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(true);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.True(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForUrlWithEmptyCredential()
        {
            ApiCredential apiCredential = new(string.Empty, string.Empty);
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(false);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.False(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnTrueForUrlWithSpaceInCredential()
        {
            ApiCredential apiCredential = new(" ", " ");
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(true);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.True(isApiHealthy);
        }

        [Fact]
        public void Can_IsApiHealthy_ReturnFalseForUrlWithSpaceInCredential()
        {
            ApiCredential apiCredential = new(" ", " ");
            ApiDetail apiDetail = new("demo name", "demo url", apiCredential, true);

            _healthCheckMock
                .Setup(s => s.IsHealthy(apiDetail.Url, null))
                .Returns(false);

            bool isApiHealthy = _commonHealthCheck.IsApiHealthy(apiDetail);

            Assert.False(isApiHealthy);
        }
    }
}

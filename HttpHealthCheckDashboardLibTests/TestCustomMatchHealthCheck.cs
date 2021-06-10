using ArnabDeveloper.HttpHealthCheck;
using HttpHealthCheckDashboardLib;
using System;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLibTests
{
    public class TestCustomMatchHealthCheck : BaseHealthCheck
    {
        public TestCustomMatchHealthCheck(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }

        protected override Predicate<ApiDetail> GetMatch()
        {
            int indexOfHealthCheck = GetType().Name.IndexOf("CustomMatchHealthCheck");
            string apiNameToTest = GetType().Name.Substring(0, indexOfHealthCheck);
            return new Predicate<ApiDetail>(u => u.Name == apiNameToTest && u.IsEnable);
        }
    }
}

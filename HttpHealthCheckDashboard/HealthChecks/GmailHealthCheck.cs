using Arc.HttpHealthCheckDashboard;
using ArnabDeveloper.HttpHealthCheck;
using System;
using System.Collections.Generic;

namespace HttpHealthCheckDashboard
{
    public class GmailHC : BaseHealthCheck
    {
        public GmailHC(IEnumerable<ApiDetail> urlDetails, ICommonHealthCheck commonHealthCheck)
            : base(urlDetails, commonHealthCheck)
        {
        }

        protected override Predicate<ApiDetail> GetMatch()
        {
            int indexOfHealthCheck = GetType().Name.IndexOf("HC");
            string apiNameToTest = GetType().Name.Substring(0, indexOfHealthCheck);
            return new Predicate<ApiDetail>(u => u.Name == apiNameToTest && u.IsEnable);
        }
    }
}

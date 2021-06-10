using ArnabDeveloper.HttpHealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpHealthCheckDashboardLib
{
    public class ApiDetailFinder : IApiDetailFinder
    {
        ApiDetail? IApiDetailFinder.FindApiDetail(IEnumerable<ApiDetail> urlDetails, Predicate<ApiDetail> match)
        {
            return urlDetails.ToList().Find(match);
        }
    }
}

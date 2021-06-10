using ArnabDeveloper.HttpHealthCheck;
using System;
using System.Collections.Generic;

namespace HttpHealthCheckDashboardLib
{
    public interface IApiDetailFinder
    {
        ApiDetail? FindApiDetail(IEnumerable<ApiDetail> urlDetails, Predicate<ApiDetail> match);
    }
}

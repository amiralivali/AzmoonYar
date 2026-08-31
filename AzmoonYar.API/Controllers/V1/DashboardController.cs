using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Dashboard;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;

[ApiVersion(1.0)]
public class DashboardController(DashboardService service) : BaseController
{
    [HttpGet(DashboardUriConstants.GetSummary)]
    public async Task<ApiResult<SummaryResponse>> GetSummary(CancellationToken cancellationToken)
    {
        var result = await service.GetSummaryAsync(cancellationToken);
        return result.ToResponse();
    }
}
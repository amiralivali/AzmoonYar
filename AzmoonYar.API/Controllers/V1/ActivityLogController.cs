using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.ActivityLog;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Common;
using AzmoonYar.Application.Services;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;
[ApiVersion(1.0)]
public class ActivityLogController(IActivityLogService service) : BaseController
{
    [HttpGet(ActivityLogUriConstants.GetAll)]
    public async Task<ApiResult<PagedResult<ActivityLogResponse>>> GetAll([FromQuery]GetActivityLogRequest request,CancellationToken cancellationToken)
    {
        var result = await service.GetAllAsync(request.ToDto(),cancellationToken);
        return result.ToResponse();
    }
}
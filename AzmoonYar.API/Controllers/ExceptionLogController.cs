using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.ExceptionLog;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
public class ExceptionLogController(ExceptionLogService service) : BaseController
{
    [HttpGet(ExceptionLogUriConstants.GetAll)]
    public async Task<ApiResult<List<ExceptionLogResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var logs = await service.GetAllAsync(cancellationToken);
        return logs.Select(x => x.ToResponse()).ToList();
    }
    
    [HttpGet(ExceptionLogUriConstants.GetById)]
    public async Task<ApiResult<ExceptionLogResponse>> GetById(string id, CancellationToken cancellationToken)
    {
        var log = await service.GetByIdAsync(id,cancellationToken);
        return log.ToResponse();
    }
    
    [HttpGet(ExceptionLogUriConstants.GetRecent)]
    public async Task<ApiResult<List<ExceptionLogResponse>>> GetRecent(int count , CancellationToken cancellationToken)
    {
        var logs = await service.GetRecentAsync(count,cancellationToken);
        return logs.Select(x => x.ToResponse()).ToList();
    }
}
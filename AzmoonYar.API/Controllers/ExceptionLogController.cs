using AzmoonYar.API.Contracts.ExceptionLog;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExceptionLogController(ExceptionLogService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ExceptionLogResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var logs = await service.GetAllAsync(cancellationToken);
        return Ok(logs.Select(x=>x.ToResponse()).ToList());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ExceptionLogResponse>> GetById(string id, CancellationToken cancellationToken)
    {
        var log = await service.GetByIdAsync(id,cancellationToken);
        return Ok(log.ToResponse());
    }
    [HttpGet("recent")]
    public async Task<ActionResult<IReadOnlyList<ExceptionLogResponse>>> GetRecent(int count , CancellationToken cancellationToken)
    {
        var logs = await service.GetRecentAsync(count,cancellationToken);
        return Ok(logs.Select(x=>x.ToResponse()).ToList());
    }
}
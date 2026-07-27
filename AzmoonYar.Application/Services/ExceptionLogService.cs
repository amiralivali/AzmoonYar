using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.ExceptionLog;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;


namespace AzmoonYar.Application.Services;

public class ExceptionLogService(IExceptionLogRepository repository)
{
    public async Task<IReadOnlyList<ExceptionLogDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var logs = await repository.GetAllAsync(cancellationToken);
        return logs.Select(ToDto).ToList();
    }

    public async Task<ExceptionLogDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var log = await repository.GetByIdAsync(id, cancellationToken)
                  ?? throw new EntityNotFoundException(nameof(ExceptionLog), id);

        return ToDto(log);
    }

    public async Task<IReadOnlyList<ExceptionLogDto>> GetRecentAsync(int count,
        CancellationToken cancellationToken = default)
    {
        var logs = await repository.GetRecentAsync(count, cancellationToken);
        return logs.Select(ToDto).ToList();
    }
    private static ExceptionLogDto ToDto(ExceptionLog log) => new(
        log.Id!,
        log.ExceptionType,
        log.Message,
        log.StackTrace,
        log.Source,
        log.RequestPath,
        log.RequestMethod,
        log.StatusCode,
        log.CreatedAt);
}
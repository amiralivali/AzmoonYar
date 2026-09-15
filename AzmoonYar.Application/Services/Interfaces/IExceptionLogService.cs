using AzmoonYar.Application.DTOs.ExceptionLog;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IExceptionLogService
{
    Task<IReadOnlyList<ExceptionLogDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ExceptionLogDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ExceptionLogDto>> GetRecentAsync(int count,
        CancellationToken cancellationToken = default);
}
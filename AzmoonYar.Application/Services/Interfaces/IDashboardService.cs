using AzmoonYar.Application.DTOs.Dashboard;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IDashboardService
{
    Task<SummaryDto> GetSummaryAsync(CancellationToken cancellationToken = default);
}
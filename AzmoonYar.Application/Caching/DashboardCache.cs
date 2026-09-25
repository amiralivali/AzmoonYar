using AzmoonYar.Application.Caching.Constants;
using AzmoonYar.Application.DTOs.Dashboard;
using AzmoonYar.Application.Interfaces;

namespace AzmoonYar.Application.Caching;

public class DashboardCache(ICacheService service)
{
    private static readonly TimeSpan CachedExpiration = TimeSpan.FromMinutes(10);

    public Task<SummaryDto> GetSummaryAsync(
        long userId,
        Func<CancellationToken, Task<SummaryDto>> factory,
        CancellationToken cancellationToken = default)
        => service.GetOrCreateAsync(
            DashboardCacheKeyConstants.GetSummaryCacheKey(userId),
            factory,
            CachedExpiration,
            cancellationToken);

    public async Task InvalidateAsync(long userId, CancellationToken cancellationToken)
    {
        await service.RemoveAsync(DashboardCacheKeyConstants.GetSummaryCacheKey(userId), cancellationToken);
    }
}
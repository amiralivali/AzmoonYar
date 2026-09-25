namespace AzmoonYar.Application.Caching.Constants;

public static class DashboardCacheKeyConstants
{
    public static string GetSummaryCacheKey(long userId) => $"dashboard:summary:{userId}";
}
using AzmoonYar.Application.Caching.Constants;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Caching;

public class QuestionCache(ICacheService service)
{
    private static readonly TimeSpan CachedExpiration = TimeSpan.FromMinutes(10);
    
    public Task<(IReadOnlyList<QuestionDto> questions, int totalCount)> GetAllAsync(
        Func<CancellationToken, Task<(IReadOnlyList<QuestionDto> questions, int totalCount)>> factory,
        CancellationToken cancellationToken = default)
         => service.GetOrCreateAsync(QuestionCacheKeyConstants.All,
            factory,
            CachedExpiration,
            cancellationToken);

    public Task<QuestionDto> GetByIdAsync(long id,
        Func<CancellationToken, Task<QuestionDto>> factory,
        CancellationToken cancellationToken = default)
        => service.GetOrCreateAsync(QuestionCacheKeyConstants.ById(id),
            factory,
            CachedExpiration,
            cancellationToken);
    

    public Task<int> GetQuestionsCountByLessonIdAsync(long lessonId,
        Func<CancellationToken, Task<int>> factory,
        CancellationToken cancellationToken = default)
        => service.GetOrCreateAsync(QuestionCacheKeyConstants.CountByLessonId(lessonId),
            factory,
            CachedExpiration,
            cancellationToken);

    public async Task InvalidateAsync(long id,long lessonId , CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(QuestionCacheKeyConstants.CountByLessonId(lessonId), cancellationToken);
        await service.RemoveAsync(QuestionCacheKeyConstants.ById(id), cancellationToken);
        await service.RemoveAsync(QuestionCacheKeyConstants.All, cancellationToken);
    }

}
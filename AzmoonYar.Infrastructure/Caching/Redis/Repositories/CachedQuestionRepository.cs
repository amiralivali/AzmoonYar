using AzmoonYar.Application.CacheKeys;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Infrastructure.Caching.Redis.Repositories;

public class CachedQuestionRepository(ICacheService cacheService, IQuestionRepository inner) : IQuestionRepository
{
    private readonly List<string> _pendingInvalidations = [];

    public Task<IReadOnlyList<Question>> GetAllAsync(CancellationToken cancellationToken = default) =>
        cacheService.GetOrCreateAsync(
            QuestionKeys.AllQuestions,
            () => inner.GetAllAsync(cancellationToken),
            TimeSpan.FromMinutes(10),
            cancellationToken)!;

    public Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(QuestionType questionType, CancellationToken cancellationToken = default) =>
        cacheService.GetOrCreateAsync(
            QuestionKeys.AllByType(questionType),
            () => inner.GetAllByQuestionTypeAsync(questionType, cancellationToken),
            TimeSpan.FromMinutes(10),
            cancellationToken)!;

    public async Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default)
    {
        return await inner.GetFillInBlankItemByIdAsync(itemId, cancellationToken);
    }

    public async Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default)
    {
        return await cacheService.GetOrCreateAsync(
            QuestionKeys.QuestionCount,
            () => inner.GetQuestionsCountByLessonIdAsync(lessonId, cancellationToken),
            TimeSpan.FromMinutes(10),
            cancellationToken);
    }

    public Task<Question?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        cacheService.GetOrCreateAsync(
            QuestionKeys.ById(id),
            () => inner.GetByIdAsync(id, cancellationToken),
            TimeSpan.FromMinutes(10),
            cancellationToken);

    public async Task AddAsync(Question entity, CancellationToken cancellationToken = default)
    {
        await inner.AddAsync(entity, cancellationToken);
        _pendingInvalidations.Add(QuestionKeys.AllQuestions);
        _pendingInvalidations.Add(QuestionKeys.AllByType(entity.QuestionType));
    }

    public void Update(Question entity)
    {
        inner.Update(entity);
        _pendingInvalidations.Add(QuestionKeys.ById(entity.Id));
        _pendingInvalidations.Add(QuestionKeys.AllQuestions);
        _pendingInvalidations.Add(QuestionKeys.AllByType(entity.QuestionType));
    }

    public void Delete(Question entity)
    {
        inner.Delete(entity);
        _pendingInvalidations.Add(QuestionKeys.ById(entity.Id));
        _pendingInvalidations.Add(QuestionKeys.AllQuestions);
        _pendingInvalidations.Add(QuestionKeys.AllByType(entity.QuestionType));
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await inner.SaveChangesAsync(cancellationToken);
        foreach (var key in _pendingInvalidations.Distinct())
            await cacheService.RemoveAsync(key, cancellationToken);
        _pendingInvalidations.Clear();
        return result;
    }
}
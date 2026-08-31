using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    Task<PagedResult<Question>> GetAllAsync(string? searchPhase, long? bookId,
        long? lessonId, DifficultyLevel? difficultyLevel,
        Grade? grade, QuestionType? questionType,
        int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    // Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(QuestionType questionType,
    //     CancellationToken cancellationToken = default);

    Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default);
    Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default);
    Task<Dictionary<QuestionType, int>> CountByTypeAsync(CancellationToken cancellationToken = default);
}
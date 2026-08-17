using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    Task<IReadOnlyList<Question>> GetAllAsync(string? searchPhase, long? bookId,
        long? lessonId, DifficultyLevel? difficultyLevel,
        Grade? grade ,QuestionType? questionType,
        CancellationToken cancellationToken);

    // Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(QuestionType questionType,
    //     CancellationToken cancellationToken = default);

    Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default);
    Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default);
}
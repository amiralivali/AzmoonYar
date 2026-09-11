using AzmoonYar.Application.Common;
using AzmoonYar.Application.Specification.Question;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    Task<PagedResult<Question>> GetAllAsync(QuestionQueryFilterSpec  queryFilterSpec,
        CancellationToken cancellationToken);

    // Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(QuestionType questionType,
    //     CancellationToken cancellationToken = default);

    Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default);
    Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default);
    Task<Dictionary<QuestionType, int>> CountByTypeAsync(CancellationToken cancellationToken = default);
}
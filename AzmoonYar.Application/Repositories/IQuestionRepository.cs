using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(QuestionType questionType, CancellationToken cancellationToken = default);
    Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default);
}
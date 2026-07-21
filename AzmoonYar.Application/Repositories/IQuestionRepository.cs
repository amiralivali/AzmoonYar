using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<BaseQuestion>
{
    Task<IReadOnlyList<BaseQuestion>> GetAllAsync(QuestionType questionType, CancellationToken cancellationToken = default);
}
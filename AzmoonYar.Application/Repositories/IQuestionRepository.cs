using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Repositories;

public interface IQuestionRepository : IRepository<BaseQuestion>
{
    Task<IReadOnlyList<DescriptiveQuestion>> GetAllDescriptiveQuestions();
    Task<IReadOnlyList<ShortAnswerQuestion>> GetAllShortAnswerQuestions();
    Task<IReadOnlyList<FillInBlankQuestion>> GetAllFillInBlankQuestions();
    Task<IReadOnlyList<TrueFalseQuestion>> GetAllTrueFalseQuestions();
    Task<IReadOnlyList<OptionalQuestion>> GetAllOptionalQuestions();
    Task<IReadOnlyList<MatchingQuestion>> GetAllMatchingQuestions();
}
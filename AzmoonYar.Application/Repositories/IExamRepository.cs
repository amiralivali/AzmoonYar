using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Repositories;

public interface IExamRepository : IRepository<Exam>
{
    Task<PagedResult<Exam>> GetAllAsync(string? searchPhrase,
        Grade? grade,
        long? bookId,
        ExamDifficultyLevel? examDifficultyLevel,
        ExamType? examType,
        QuestionType? questionType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);
    byte[] GenerateExamPdf(Exam exam);
}
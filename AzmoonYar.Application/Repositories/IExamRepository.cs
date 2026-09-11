using AzmoonYar.Application.Common;
using AzmoonYar.Application.Specification.Exam;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Repositories;

public interface IExamRepository : IRepository<Exam>
{
    Task<PagedResult<Exam>> GetAllAsync(ExamQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken);
    byte[] GenerateExamPdf(Exam exam);
}
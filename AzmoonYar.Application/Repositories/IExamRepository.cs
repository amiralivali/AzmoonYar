using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Repositories;

public interface IExamRepository : IRepository<Exam>
{
    byte[] GenerateExamPdf(Exam exam);
}
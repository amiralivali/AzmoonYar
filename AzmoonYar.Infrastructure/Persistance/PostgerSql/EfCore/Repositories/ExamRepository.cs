using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class ExamRepository(AzmoonYarDbContext context) : RepositoryBase<Exam>(context) , IExamRepository
{
    
}
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context) : RepositoryBase<BaseQuestion>(context) , IQuestionRepository
{
    private readonly AzmoonYarDbContext _context = context;
    public async Task<IReadOnlyList<BaseQuestion>> GetAllAsync(QuestionType questionType, CancellationToken cancellationToken = default)
    {
        return await _context.Questions.Where(x => x.QuestionType == questionType).AsNoTracking().ToListAsync(cancellationToken);
    }
}
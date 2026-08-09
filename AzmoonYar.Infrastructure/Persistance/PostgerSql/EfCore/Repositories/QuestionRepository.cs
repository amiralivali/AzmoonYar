using System.Collections.Immutable;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context)
    : RepositoryBase<Question>(context), IQuestionRepository
{
    public override async Task<Question?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await Context.Questions
            .Include(x=>x.FillInBlankItems)
            .Include(x=>x.TrueFalseItems)
            .Include(x=>x.MatchingItems)
            .Include(x=>x.OptionalItem)
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id==id,cancellationToken);
    }

    public async Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(
        QuestionType questionType,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Questions
            .Where(x => x.QuestionType == questionType);

        query = questionType switch
        {
            QuestionType.FillInBlank =>
                query.Include(x => x.FillInBlankItems),

            QuestionType.Matching =>
                query.Include(x => x.MatchingItems),

            QuestionType.TrueFalse =>
                query.Include(x => x.TrueFalseItems),

            QuestionType.Optional =>
                query.Include(x => x.OptionalItem),

            QuestionType.Descriptive or QuestionType.ShortAnswer =>
                query,

            _ => throw new InvalidQuestionType()
        };

        return await query
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default)
    {
        return await Context.FillInBlankItems.FirstOrDefaultAsync(x=>x.Id==itemId,cancellationToken);
    }

    public async Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default)
    {
        return await Context.Questions.CountAsync(x=>x.LessonId==lessonId,cancellationToken); 
    }
}
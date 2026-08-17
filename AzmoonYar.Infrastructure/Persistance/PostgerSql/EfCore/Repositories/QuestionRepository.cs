using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context)
    : RepositoryBase<Question>(context), IQuestionRepository
{
    public async Task<IReadOnlyList<Question>> GetAllAsync(string? searchPhase,
        long? bookId,
        long? lessonId,
        DifficultyLevel? difficultyLevel,
        Grade? grade,
        QuestionType? questionType,CancellationToken cancellationToken = default)
    {
        var queryable = Context.Questions.Include(x=>x.Lesson).ThenInclude(x=>x!.Book).AsQueryable();
        if (!string.IsNullOrEmpty(searchPhase))
        {
            queryable = queryable.Where(x => EF.Functions.Contains(x.QuestionText, searchPhase));
        }

        if (bookId is not null)
        {
            queryable = queryable.Where(x => x.Lesson!.BookId == bookId);
        }
        
        if (lessonId is not null)
        {
            queryable = queryable.Where(x=>x.LessonId == lessonId);
        }

        if (difficultyLevel is not null)
        {
            queryable = queryable.Where(x=>x.DifficultyLevel == difficultyLevel);
        }

        if (grade is not null)
        {
            queryable = queryable.Where(x => x.Lesson!.Book.Grade == grade);
        }
        
        if (questionType is not null)
        {
            queryable = queryable.Where(x=>x.QuestionType == questionType);
        }
        
        return await queryable.ToListAsync(cancellationToken);
    }

    public override async Task<Question?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await Context.Questions
            .Include(x=>x.FillInBlankItems)
            .ThenInclude(x=>x.Answers)
            .Include(x=>x.TrueFalseItems)
            .Include(x=>x.MatchingItems)
            .Include(x=>x.OptionalItem)
            .FirstOrDefaultAsync(x=>x.Id==id,cancellationToken);
    }

    // public async Task<IReadOnlyList<Question>> GetAllByQuestionTypeAsync(
    //     QuestionType questionType,
    //     CancellationToken cancellationToken = default)
    // {
    //     var query = Context.Questions
    //         .Where(x => x.QuestionType == questionType);
    //
    //     query = questionType switch
    //     {
    //         QuestionType.FillInBlank =>
    //             query.Include(x => x.FillInBlankItems).ThenInclude(x=>x.Answers),
    //
    //         QuestionType.Matching =>
    //             query.Include(x => x.MatchingItems),
    //
    //         QuestionType.TrueFalse =>
    //             query.Include(x => x.TrueFalseItems),
    //
    //         QuestionType.Optional =>
    //             query.Include(x => x.OptionalItem),
    //
    //         QuestionType.Descriptive or QuestionType.ShortAnswer =>
    //             query,
    //
    //         _ => throw new InvalidQuestionType()
    //     };
    //
    //     return await query
    //         .ToListAsync(cancellationToken);
    // }

    public async Task<FillInBlankItem?> GetFillInBlankItemByIdAsync(long itemId, CancellationToken cancellationToken = default)
    {
        return await Context.FillInBlankItems.FirstOrDefaultAsync(x=>x.Id==itemId,cancellationToken);
    }

    public async Task<int> GetQuestionsCountByLessonIdAsync(long lessonId, CancellationToken cancellationToken = default)
    {
        return await Context.Questions.CountAsync(x=>x.LessonId==lessonId,cancellationToken); 
    }
}
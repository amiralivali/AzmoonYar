using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context)
    : RepositoryBase<Question>(context), IQuestionRepository
{
    public async Task<PagedResult<Question>> GetAllAsync(string? searchPhase,
        long? bookId,
        long? lessonId,
        DifficultyLevel? difficultyLevel,
        Grade? grade,
        QuestionType? questionType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var queryable = Context.Questions.Include(x=>x.Lesson).ThenInclude(x=>x!.Book).AsQueryable();
        if (!string.IsNullOrEmpty(searchPhase))
        {
            queryable = queryable.Where(x=> x.QuestionText.Contains(searchPhase));
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
        var totalCount = await  queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var questions = await queryable.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(cancellationToken);
        return new PagedResult<Question>(questions, pageNumber, pageSize, totalCount, totalPages);
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

    public async Task<Dictionary<QuestionType, int>> CountByTypeAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Questions
            .GroupBy(x=>x.QuestionType)
            .Select(x=>new { Type = x.Key, Count = x.Count() })
            .ToDictionaryAsync(k=>k.Type, v=>v.Count,cancellationToken);
    }
}
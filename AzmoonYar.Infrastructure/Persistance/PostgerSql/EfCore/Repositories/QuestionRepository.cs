using AzmoonYar.Application.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Specification.Question;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using AzmoonYar.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context)
    : RepositoryBase<Question>(context), IQuestionRepository
{
    public async Task<PagedResult<Question>> GetAllAsync(QuestionQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken = default)
    {
        var pageNumber = queryFilterSpec.PageNumber;
        var pageSize = queryFilterSpec.PageSize;
        var queryable = Context.Questions.Include(x=>x.Lesson).ThenInclude(x=>x!.Book).AsQueryable();
        if (!string.IsNullOrEmpty(queryFilterSpec.SearchPhase))
        {
            queryable = queryable.Where(x=> x.QuestionText.Contains(queryFilterSpec.SearchPhase));
        }

        if (queryFilterSpec.BookId is not null)
        {
            queryable = queryable.Where(x => x.Lesson!.BookId == queryFilterSpec.BookId);
        }
        
        if (queryFilterSpec.LessonId is not null)
        {
            queryable = queryable.Where(x=>x.LessonId == queryFilterSpec.LessonId);
        }

        if (queryFilterSpec.DifficultyLevel is not null)
        {
            queryable = queryable.Where(x=>x.DifficultyLevel == queryFilterSpec.DifficultyLevel);
        }

        if (queryFilterSpec.Grade is not null)
        {
            queryable = queryable.Where(x => x.Lesson!.Book.Grade == queryFilterSpec.Grade);
        }
        
        if (queryFilterSpec.QuestionType is not null)
        {
            queryable = queryable.Where(x=>x.QuestionType == queryFilterSpec.QuestionType);
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
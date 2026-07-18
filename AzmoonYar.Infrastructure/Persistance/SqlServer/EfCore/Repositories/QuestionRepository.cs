using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public class QuestionRepository(AzmoonYarDbContext context) : RepositoryBase<BaseQuestion>(context) , IQuestionRepository
{
    private readonly AzmoonYarDbContext _context = context;
    
    public async Task<IReadOnlyList<DescriptiveQuestion>> GetAllDescriptiveQuestions()
    {
        return await _context.Questions.OfType<DescriptiveQuestion>().ToListAsync();
    }

    public async Task<IReadOnlyList<ShortAnswerQuestion>> GetAllShortAnswerQuestions()
    {
        return await _context.Questions.OfType<ShortAnswerQuestion>().ToListAsync();
    }

    public async Task<IReadOnlyList<FillInBlankQuestion>> GetAllFillInBlankQuestions()
    {
        return await _context.Questions.OfType<FillInBlankQuestion>().Include(x=>x.FillInBlankItems).ToListAsync();
    }

    public async Task<IReadOnlyList<TrueFalseQuestion>> GetAllTrueFalseQuestions()
    {
        return await _context.Questions.OfType<TrueFalseQuestion>().Include(x=>x.TrueFalseItems).ToListAsync();
    }

    public async Task<IReadOnlyList<OptionalQuestion>> GetAllOptionalQuestions()
    {
        return await _context.Questions.OfType<OptionalQuestion>().Include(x=>x.OptionalItem).ToListAsync();
    }

    public async Task<IReadOnlyList<MatchingQuestion>> GetAllMatchingQuestions()
    {
        return await _context.Questions.OfType<MatchingQuestion>().Include(x=>x.MatchingItems).ToListAsync();
    }
}
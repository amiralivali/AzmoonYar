using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Infrastructure.Reports;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class ExamRepository(AzmoonYarDbContext context) : RepositoryBase<Exam>(context) , IExamRepository
{
    public async Task<PagedResult<Exam>> GetAllAsync(string? searchPhrase, Grade? grade, long? bookId, ExamDifficultyLevel? examDifficultyLevel,
        ExamType? examType, QuestionType? questionType, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var queryable = Context.Exams.Include(x=>x.Book).Include(x=>x.ExamHeader).AsQueryable();
        if (!string.IsNullOrEmpty(searchPhrase))
        {
            queryable = queryable.Where(x=> x.Book.BookName.ToLower().Contains(searchPhrase.ToLower())
                                            || x.ExamHeader.ExamTitle.ToLower().Contains(searchPhrase.ToLower()));
        }

        if (bookId is not null)
        {
            queryable = queryable.Where(x => x.BookId == bookId);
        }
        
        if (examDifficultyLevel is not null)
        {
            queryable = queryable.Where(x=>x.DifficultyLevel == examDifficultyLevel);
        }

        if (grade is not null)
        {
            queryable = queryable.Where(x => x.Book.Grade == grade);
        }
        
        if (examType is not null)
        {
            queryable = queryable.Where(x => x.ExamType == examType);
        }
        
        /*if (questionType is not null)
        {
            queryable = queryable.Where(x=>x.ExamQuestionTypes.Contains(questionType));
        }*/
        
        var totalCount = await queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var exams = await queryable.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(cancellationToken);
        return new PagedResult<Exam>(exams, pageNumber, pageSize, totalCount, totalPages);
    }

    public byte[] GenerateExamPdf(Exam exam)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        var document = new ExamDocument(exam);
        return document.GeneratePdf();
    }
}
using AzmoonYar.Application.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Specification.Exam;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;
using AzmoonYar.Infrastructure.Reports;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class ExamRepository(AzmoonYarDbContext context) : RepositoryBase<Exam>(context) , IExamRepository
{
    public async Task<PagedResult<Exam>> GetAllAsync(ExamQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken)
    {
        var pageNumber = queryFilterSpec.PageNumber;
        var pageSize = queryFilterSpec.PageSize;
        var queryable = Context.Exams.Include(x=>x.Book).Include(x=>x.ExamHeader).AsQueryable();
        if (!string.IsNullOrEmpty(queryFilterSpec.SearchPhrase))
        {
            queryable = queryable.Where(x=> x.Book.BookName.ToLower().Contains(queryFilterSpec.SearchPhrase.ToLower())
                                            || x.ExamHeader.ExamTitle.ToLower().Contains(queryFilterSpec.SearchPhrase.ToLower()));
        }

        if (queryFilterSpec.BookId is not null)
        {
            queryable = queryable.Where(x => x.BookId == queryFilterSpec.BookId);
        }
        
        if (queryFilterSpec.ExamDifficultyLevel is not null)
        {
            queryable = queryable.Where(x=>x.DifficultyLevel == queryFilterSpec.ExamDifficultyLevel);
        }

        if (queryFilterSpec.Grade is not null)
        {
            queryable = queryable.Where(x => x.Book.Grade == queryFilterSpec.Grade);
        }
        
        if (queryFilterSpec.ExamType is not null)
        {
            queryable = queryable.Where(x => x.ExamType == queryFilterSpec.ExamType);
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
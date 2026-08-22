using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Infrastructure.Reports;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class ExamRepository(AzmoonYarDbContext context) : RepositoryBase<Exam>(context) , IExamRepository
{
    public byte[] GenerateExamPdf(Exam exam)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        var document = new ExamDocument(exam);
        return document.GeneratePdf();
    }
}
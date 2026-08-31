using System.Xml;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.DTOs.Exam;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Services;

public class ExamService(IExamRepository examRepository, IBookRepository bookRepository)
{
    public async Task<PagedResult<ExamDto>> GetAllAsync(GetExamDto request, CancellationToken cancellationToken)
    {
        var result = await examRepository.GetAllAsync(request.SearchPhrase,request.Grade,
            request.BookId,request.ExamDifficultyLevel,
            request.ExamType,request.QuestionType,
            request.PageNumber,request.PageSize
            ,cancellationToken);
        return ToDto(result);
    }

/*public async Task<long> CreateManualAsync(CreateManualExamDto dto, CancellationToken cancellationToken = default)
{
    var lessons = await bookRepository.GetLessonsByLessonIds(dto.LessonIds, cancellationToken);

    var header = ExamHeader.Create(
        dto.ExamHeader.SchoolName,
        dto.ExamHeader.ExamTitle,
        dto.ExamHeader.TeacherName,
        dto.ExamHeader.ClassName,
        dto.ExamHeader.ExamDate,
        dto.ExamHeader.DurationMinutes,
        dto.ExamHeader.LogoPicture);

    var exam = new Exam(dto.BookId, lessons, dto.ExamType, dto.DifficultyLevel,header);

    foreach (var qt in dto.QuestionTypes)
        exam.AddQuestionType(qt.QuestionType, qt.Count);

    foreach (var q in dto.Questions)
        exam.AddQuestion(q.QuestionId, q.Score, q.ShuffleOptions);

    await examRepository.AddAsync(exam, cancellationToken);
    await examRepository.SaveChangesAsync(cancellationToken);
    return exam.Id;
}

public async Task<long> CreateAutomaticAsync(CreateAutomaticExamDto dto, CancellationToken ct = default)
{
    var lessons = await examRepository.GetLessonsByIdsAsync(dto.LessonIds, ct);
    var exam = new Exam(dto.BookId, lessons, dto.ExamType, dto.DifficultyLevel);

    foreach (var qt in dto.QuestionTypes)
        exam.AddQuestionType(qt.QuestionType, qt.Count);

    var selected = await _questionSelector.SelectAsync(
        dto.LessonIds, dto.DifficultyLevel, dto.QuestionTypes, ct);

    foreach (var q in selected)
        exam.AddQuestion(q.QuestionId, q.Score);

    await examRepository.AddAsync(exam, ct);
    await examRepository.SaveChangesAsync(ct);
    return exam.Id;
}*/

    private static PagedResult<ExamDto> ToDto(PagedResult<Exam> result)
        => new (result.Items.Select(ToDto).ToList(),
            result.PageNumber,
            result.PageSize,
            result.TotalCount,
            result.TotalPages);

    private static ExamDto ToDto(Exam exam)
        => new(exam.Id, exam.ExamHeader.ExamTitle, exam.ExamStatus, exam.ExamType, exam.CreatedAt);
}
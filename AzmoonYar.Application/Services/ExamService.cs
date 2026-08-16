using System.Xml;
using AzmoonYar.Application.DTOs.Exam;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class ExamService(IExamRepository examRepository,IBookRepository bookRepository)
{
    public async Task<long> CreateExamAsync(CreateExamDto dto, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(dto.BookId, cancellationToken);
        if (book is null)
            throw new EntityNotFoundException(nameof(Book), dto.BookId);
    
        var lessons = book.Lessons
            .Where(l => dto.LessonIds.Contains(l.Id))
            .ToList();
    
        if (lessons.Count != dto.LessonIds.Count)
            throw new LessonNotFoundInBookException();
    
        var exam = new Exam(dto.BookId, lessons, dto.ExamType, dto.DifficultyLevel);
        if (!string.IsNullOrWhiteSpace(dto.HeaderPicture))
        {
            exam.SetHeaderImage(dto.HeaderPicture);
        }
        else if (!string.IsNullOrWhiteSpace(dto.HeaderText))
        {
            exam.SetCustomHeader(dto.HeaderText, dto.LogoPicture);
        }
        foreach (var question in dto.Questions)
        {
            exam.AddQuestion(question.QuestionId,question.Score,question.ShuffleOptions);
        }
    
        foreach (var questionType in dto.QuestionTypes)
        {
            exam.AddQuestionType(questionType.QuestionType,questionType.Count);
        }
        
        await examRepository.AddAsync(exam, cancellationToken);
        await examRepository.SaveChangesAsync(cancellationToken);
    
        return exam.Id;
    }
    //Create Auto Question
    //Manuly Select Question
}
using System.Data;
using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class BookService(IBookRepository repository, ActivityLogService logService) 
{
    public async Task<IReadOnlyList<BookDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var books = await repository.GetAllAsync(cancellationToken);
        return books.Select(ToDto).ToList();
    }
    public async Task<BookDto> AddAsync(CreateBookDto dto,CancellationToken cancellationToken = default)
    {
        var book = new Book(dto.BookName, dto.Grade);
        book.ChangeGradeInfo(dto.GradeInfo);
        foreach (var lesson in dto.CreateLessonDtos)
        {
            book.AddLesson(lesson.Title);
        }
        await repository.AddAsync(book,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        //fix id
        await logService.AddAsync(new BookCreatedLogData(book.BookName,book.Grade.ToPersian()),1);
        return ToDto(book);
    }

    public async Task<BookDto> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(id, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(Book), id);
        return ToDto(book);
    }
    
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var book = await repository.GetByIdAsync(id, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(Book), id);
        repository.Delete(book);
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new BookDeletedLogData(book.BookName,book.Grade.ToPersian()),1);
    }

    public async Task<BookDto> UpdateAsync(long id, UpdateBookDto dto, CancellationToken cancellationToken = default)
    {
        var book = await repository.GetByIdAsync(id, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(Book), id);
        book.UpdateBook(dto.BookName, dto.Grade);
        if (dto.GradeInfo != null)
        {
            book.ChangeGradeInfo(dto.GradeInfo);
        }
        foreach (var lessonDto in dto.UpdateLessonDtos.Where(lessonDto => !string.IsNullOrEmpty(lessonDto.Title)))
        {
            book.ChangeLessonTitle(lessonDto.Id, lessonDto.Title!);
        }
        repository.Update(book);
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new BookUpdatedLogData(book.BookName,book.Grade.ToPersian()),1);
        return ToDto(book);
    }
    
    public async Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default)
    {
        var grades = await repository.GetAvailableGradesAsync(cancellationToken);
        return grades;
    }

    public async Task<IReadOnlyList<BookDto>> GetBooksByGradeAsync(Grade grade,
        CancellationToken cancellationToken = default)
    {
        var books = await repository.GetBooksByGrade(grade, cancellationToken);
        return books.Select(ToDto).ToList();
    }
    
    public async Task<IReadOnlyList<LessonDto>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken = default)
    {
        var books = await repository.GetLessonsByBookId(bookId, cancellationToken);
        return books.Select(ToDto).ToList();
    }

    private static BookDto ToDto(Book book) => new(
        book.Id,
        book.BookName,
        book.Grade,
        book.GradeInfo,
        book.CreatedAt,
        book.Lessons.Select(x => new LessonDto(x.Id, x.LessonName, x.LessonCount)).ToList());

    private static LessonDto ToDto(Lesson lesson) => new(
        lesson.Id,
        lesson.LessonName,
        lesson.LessonCount);

}
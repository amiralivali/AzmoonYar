using AzmoonYar.API.Contracts.Book;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Application.DTOs.Lesson;

namespace AzmoonYar.API.Mappers;

public static class BookContractMapping
{
    public static CreateBookDto ToDto(this CreateBookRequest request)
    {
        return new CreateBookDto(request.BookName,request.Grade,request.GradeInfo,request.LessonRequests.Select(x=>new 
            CreateLessonDto(x.Title)).ToList());
    }
    public static UpdateBookDto ToDto(this UpdateBookRequest request)
    {
        return new UpdateBookDto(request.BookName,request.Grade,request.GradeInfo,request.UpdateLessonRequests.Select(x=>new 
            UpdateLessonDto(x.Title)).ToList());
    }
    public static BookResponse ToResponse(this BookDto dto)
    {
        return new BookResponse(dto.Id,
            dto.BookName,
            dto.Grade,
            dto.GradeInfo,
            dto.CreatedAt,
            dto.Lessons.Select(x=>new LessonResponse(x.Id,x.LessonName,x.LessonCount)).ToList());
    }
}
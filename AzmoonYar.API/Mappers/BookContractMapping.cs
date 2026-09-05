using AzmoonYar.API.Contracts.Book;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Application.DTOs.Files;

namespace AzmoonYar.API.Mappers;

public static class BookContractMapping
{
    public static CreateBookDto ToDto(this CreateBookRequest request)
    {
        var coverImage = request.CoverImage is null
            ? null
            : new FileUploadDto(
                request.CoverImage.OpenReadStream(),
                request.CoverImage.FileName);
        return new CreateBookDto(request.BookName,request.Grade,request.BookSource,request.LessonRequests.Select(x=>new 
            CreateLessonDto(x.Title)).ToList(),coverImage);
    }
    public static UpdateBookDto ToDto(this UpdateBookRequest request)
    {
        var coverImage = request.CoverImage is null
            ? null
            : new FileUploadDto(
                request.CoverImage.OpenReadStream(),
                request.CoverImage.FileName);
        return new UpdateBookDto(request.BookName,request.Grade,request.BookSource,request.UpdateLessonRequests.Select(x=>new 
            UpdateLessonDto(x.Id,x.Title)).ToList(),coverImage);
    }
    public static BookResponse ToResponse(this BookDto dto)
    {
        return new BookResponse(dto.Id,
            dto.BookName,
            dto.Grade,
            dto.BookSource,
            dto.CreatedAt,
            dto.Lessons.Select(x=>new LessonResponse(x.Id,x.LessonName,x.LessonCount)).ToList(),
            dto.CoverImageUrl);
    }
    public static LessonResponse ToResponse(this LessonDto dto)
    {
        return new LessonResponse(dto.Id,
            dto.LessonName,
            dto.LessonCount);
    }
}
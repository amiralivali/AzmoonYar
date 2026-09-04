using AzmoonYar.API.Contracts.ActivityLog;
using AzmoonYar.API.Contracts.Book;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Application.DTOs.Common;

namespace AzmoonYar.API.Mappers;

public static class BookContractMapping
{
    public static CreateBookDto ToDto(this CreateBookRequest request)
    {
        return new CreateBookDto(request.BookName,request.Grade,request.Picture,request.LessonRequests.Select(x=>new 
            CreateLessonDto(x.Title)).ToList());
    }
    public static UpdateBookDto ToDto(this UpdateBookRequest request)
    {
        return new UpdateBookDto(request.BookName,request.Grade,request.Picture,request.UpdateLessonRequests.Select(x=>new 
            UpdateLessonDto(x.Id,x.Title)).ToList());
    }
    public static BookResponse ToResponse(this BookDto dto)
    {
        return new BookResponse(dto.Id,
            dto.BookName,
            dto.Grade,
            dto.Picture,
            dto.BookSource,
            dto.CreatedAt,
            dto.Lessons.Select(x=>new LessonResponse(x.Id,x.LessonName,x.LessonCount)).ToList());
    }
    public static GetBookDto ToDto(this GetBookRequest request)
    {
        return new GetBookDto(
            request.SearchPhase,
            request.Grade,
            request.BookSource,
            request.PageNumber,
            request.PageSize);
    }

    public static PagedResult<BookResponse> ToResponse(this PagedResult<BookDto> dto)
        => new (dto.Items.Select(x => x.ToResponse()).ToList(),
            dto.PageNumber,
            dto.PageSize,
            dto.TotalCount,
            dto.TotalPages);
    
    public static LessonResponse ToResponse(this LessonDto dto)
    {
        return new LessonResponse(dto.Id,
            dto.LessonName,
            dto.LessonCount);
    }
}
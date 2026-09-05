using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.ActivityLog;
using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;

[ApiVersion(1.0)]
public class BookController(BookService service) : BaseController
{
    [HttpGet(BookUriConstants.GetAll)]
    public async Task<ApiResult<PagedResult<BookResponse>>> GetAll([FromQuery]GetBookRequest request,CancellationToken cancellationToken)
    {
        var books = await service.GetAllAsync(request.ToDto(), cancellationToken);
        return books.ToResponse();
    }
    
    [HttpGet(BookUriConstants.GetById)]
    public async Task<ApiResult<BookResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var dto = await service.GetByIdAsync(id, cancellationToken);
        return dto.ToResponse();
    }
    
    [HttpGet(BookUriConstants.GetAvailableGrades)] 
    public async Task<ApiResult<IReadOnlyList<Grade>>> GetAvailableGrades(CancellationToken cancellationToken)
    {
        var grades = await service.GetAvailableGradesAsync(cancellationToken);
        return grades.ToList().AsReadOnly();
    }

    [HttpGet(BookUriConstants.GetBooksByGrade)]
    public async Task<ApiResult<IReadOnlyList<BookResponse>>> GetBooksByGrade(Grade grade,
        CancellationToken cancellationToken)
    {
        var books = await service.GetBooksByGradeAsync(grade, cancellationToken);
        return books.Select(x=>x.ToResponse()).ToList();
    }
    
    [HttpGet(BookUriConstants.GetLessonsByBookId)]
    public async Task<ApiResult<IReadOnlyList<LessonResponse>>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken)
    {
        var books = await service.GetLessonsByBookId(bookId, cancellationToken);
        return books.Select(x=>x.ToResponse()).ToList();
    }
    
    [HttpPost(BookUriConstants.Add)]
    public async Task<ApiResult<BookResponse>> Add(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.AddAsync(request.ToDto(),cancellationToken);
        var response = book.ToResponse();
        return ApiResult<BookResponse>.Created(response,$"/api/v1/book/{response.Id}");
    }

    [HttpPut(BookUriConstants.Update)]
    public async Task<ApiResult<BookResponse>> Update(long id,UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
        return book.ToResponse();
    }
    
    [HttpDelete(BookUriConstants.Delete)]
    public async Task<ApiResult> Delete(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id,cancellationToken);
        return ApiResult.NoContent();
    }
}
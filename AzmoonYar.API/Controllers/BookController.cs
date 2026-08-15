using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
public class BookController(BookService service) : BaseController
{
    [HttpGet(BookUriConstants.GetAll)]
    public async Task<ActionResult<IReadOnlyList<BookResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var books = await service.GetAllAsync(cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
    
    [HttpGet(BookUriConstants.GetById)]
    public async Task<ActionResult<BookResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var dto = await service.GetByIdAsync(id, cancellationToken);
        return Ok(dto.ToResponse());
    }
    
    [HttpGet(BookUriConstants.GetAvailableGrades)] 
    public async Task<ActionResult<IReadOnlyList<Grade>>> GetAvailableGrades(CancellationToken cancellationToken)
    {
        var grades = await service.GetAvailableGradesAsync(cancellationToken);
        return Ok(grades);
    }

    [HttpGet(BookUriConstants.GetBooksByGrade)]
    public async Task<ActionResult<IReadOnlyList<BookResponse>>> GetBooksByGrade(Grade grade,
        CancellationToken cancellationToken)
    {
        var books = await service.GetBooksByGradeAsync(grade, cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
    
    [HttpGet(BookUriConstants.GetLessonsByBookId)]
    public async Task<ActionResult<IReadOnlyList<LessonResponse>>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken)
    {
        var books = await service.GetLessonsByBookId(bookId, cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
    
    [HttpPost(BookUriConstants.Add)]
    public async Task<ActionResult<BookResponse>> Add(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.AddAsync(request.ToDto(),cancellationToken);
        var response = book.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut(BookUriConstants.Update)]
    public async Task<ActionResult<BookResponse>> Update(long id,UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
        return Ok(book.ToResponse());   
    }
    
    [HttpDelete(BookUriConstants.Delete)]
    public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id,cancellationToken);
        return NoContent();
    }
}
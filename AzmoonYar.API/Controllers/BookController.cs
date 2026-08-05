using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController(BookService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BookResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var books = await service.GetAllAsync(cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
    [HttpPost]
    public async Task<ActionResult<BookResponse>> Add(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.AddAsync(request.ToDto(),cancellationToken);
        var response = book.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BookResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var dto = await service.GetByIdAsync(id, cancellationToken);
        return Ok(dto.ToResponse());
    }
    
    [HttpDelete("{id:long}")]
    public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id,cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BookResponse>> Update(long id,UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var book = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
        return Ok(book.ToResponse());   
    }

    [HttpGet("grades")] 
    public async Task<ActionResult<IReadOnlyList<Grade>>> GetAvailableGrades(CancellationToken cancellationToken)
    {
        var grades = await service.GetAvailableGradesAsync(cancellationToken);
        return Ok(grades);
    }

    [HttpGet("grades/{grade}/books")]
    public async Task<ActionResult<IReadOnlyList<BookResponse>>> GetBooksByGrade(Grade grade,
        CancellationToken cancellationToken)
    {
        var books = await service.GetBooksByGradeAsync(grade, cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
    
    [HttpGet("{bookId:long}/lessons")]
    public async Task<ActionResult<IReadOnlyList<LessonResponse>>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken)
    {
        var books = await service.GetLessonsByBookId(bookId, cancellationToken);
        return Ok(books.Select(x=>x.ToResponse()).ToList());
    }
}
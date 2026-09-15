using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IBookService
{
    Task<PagedResult<BookDto>> GetAllAsync(GetBookDto request, CancellationToken cancellationToken);
    Task<BookDto> AddAsync(CreateBookDto dto, CancellationToken cancellationToken = default);
    Task<BookDto> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task<BookDto> UpdateAsync(long id, UpdateBookDto dto, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<BookDto>> GetBooksByGradeAsync(Grade grade,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LessonDto>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken = default);
}
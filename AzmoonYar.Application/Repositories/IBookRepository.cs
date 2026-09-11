using AzmoonYar.Application.Common;
using AzmoonYar.Application.Specification.Book;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Repositories;

public interface IBookRepository : IRepository<Book>
{
    Task<PagedResult<Book>> GetAllAsync(BookQueryFilterSpec queryFilterSpec,  
        CancellationToken cancellationToken);
    Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Book>> GetBooksByGrade(Grade grade,CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Lesson>> GetLessonsByBookId(long bookId, CancellationToken cancellationToken = default);
    Task<int> GetLessonCount(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Lesson>> GetLessonsByLessonIds(List<long> lessonsIds,
        CancellationToken cancellationToken = default);
}
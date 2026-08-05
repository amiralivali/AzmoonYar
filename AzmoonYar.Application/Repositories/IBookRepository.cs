using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IBookRepository : IRepository<Book>
{
    Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Book>> GetBooksByGrade(Grade grade,CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Lesson>> GetLessonsByBookId(long bookId, CancellationToken cancellationToken = default);
}
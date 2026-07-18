using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IBookRepository : IRepository<Book>
{
    Task<IReadOnlyList<Grade>> SelectAvailableGradesAsync(CancellationToken cancellationToken = default);
}
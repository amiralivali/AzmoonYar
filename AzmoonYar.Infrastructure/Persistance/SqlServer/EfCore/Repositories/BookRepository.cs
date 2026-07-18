using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public class BookRepository(AzmoonYarDbContext context) : RepositoryBase<Book>(context) , IBookRepository
{
    private readonly AzmoonYarDbContext _context = context;

    public async Task<IReadOnlyList<Grade>> SelectAvailableGradesAsync(CancellationToken cancellationToken = default)
       => await _context.Books.Select(x=>x.Grade).Distinct().ToListAsync(cancellationToken);
}
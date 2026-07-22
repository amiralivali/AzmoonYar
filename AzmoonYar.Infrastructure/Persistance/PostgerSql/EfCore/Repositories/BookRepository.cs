using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class BookRepository(AzmoonYarDbContext context) : RepositoryBase<Book>(context) , IBookRepository
{
    public override async Task<Book?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == id,cancellationToken);

    public override async Task<IReadOnlyList<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default)
       => await Context.Books.Select(x=>x.Grade).Distinct().ToListAsync(cancellationToken);
}
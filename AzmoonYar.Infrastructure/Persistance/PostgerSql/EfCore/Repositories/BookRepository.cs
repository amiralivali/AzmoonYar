using AzmoonYar.Application.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Specification.Book;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using AzmoonYar.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class BookRepository(AzmoonYarDbContext context) : RepositoryBase<Book>(context), IBookRepository
{
    public override async Task<Book?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public override async Task<IReadOnlyList<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<PagedResult<Book>> GetAllAsync(BookQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken)
    {
        var pageNumber = queryFilterSpec.PageNumber;
        var pageSize = queryFilterSpec.PageSize;
        var queryable = Context.Books.Include(x => x.Lessons).AsQueryable();
        if (!string.IsNullOrEmpty(queryFilterSpec.SearchPhase))
        {
            queryable = queryable.Where(x=> x.BookName.Contains(queryFilterSpec.SearchPhase));
        }

        if (queryFilterSpec.Grade is not null)
        {
            queryable = queryable.Where(x => x.Grade == queryFilterSpec.Grade);
        }
        
        if (queryFilterSpec.BookSource is not null)
        {
            queryable = queryable.Where(x => x.BookSource == queryFilterSpec.BookSource);
        }
        
        var totalCount = await  queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var books = await queryable.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(cancellationToken);
        return new PagedResult<Book>(books, pageNumber, pageSize, totalCount, totalPages);
    }

    public async Task<IReadOnlyList<Grade>> GetAvailableGradesAsync(CancellationToken cancellationToken = default)
        => await Context.Books.Select(x => x.Grade).Distinct().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Book>> GetBooksByGrade(Grade grade, CancellationToken cancellationToken = default)
        => await Context.Books.Where(x => x.Grade == grade).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Lesson>> GetLessonsByBookId(long bookId,
        CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).Where(x => x.Id == bookId).SelectMany(x => x.Lessons)
            .ToListAsync(cancellationToken);

    public async Task<int> GetLessonCount(CancellationToken cancellationToken = default)
        => await Context.Lessons.AsNoTracking().CountAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Lesson>> GetLessonsByLessonIds(
        List<long> lessonsIds,
        CancellationToken cancellationToken = default)
    {
        var lessons = await Context.Lessons
            .Where(x => lessonsIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        return lessons.Count != lessonsIds.Distinct().Count() ? throw new LessonNotFoundException() :
            lessons;
    }
}
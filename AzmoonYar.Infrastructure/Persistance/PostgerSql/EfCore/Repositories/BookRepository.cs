using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class BookRepository(AzmoonYarDbContext context) : RepositoryBase<Book>(context), IBookRepository
{
    public override async Task<Book?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public override async Task<IReadOnlyList<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        => await Context.Books.Include(x => x.Lessons).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<PagedResult<Book>> GetAllAsync(string? searchPhase,
        Grade? grade, 
        BookSource? bookSource,
        int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var queryable = Context.Books.Include(x => x.Lessons).AsQueryable();
        if (!string.IsNullOrEmpty(searchPhase))
        {
            queryable = queryable.Where(x=> x.BookName.Contains(searchPhase));
        }

        if (grade is not null)
        {
            queryable = queryable.Where(x => x.Grade == grade);
        }
        
        if (bookSource is not null)
        {
            queryable = queryable.Where(x => x.BookSource == bookSource);
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
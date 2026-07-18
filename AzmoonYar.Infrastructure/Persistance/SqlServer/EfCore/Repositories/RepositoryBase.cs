using AzmoonYar.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public abstract class RepositoryBase<TEntity>(AzmoonYarDbContext context) : IRepository<TEntity> where TEntity : class
{
    private readonly AzmoonYarDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public virtual void Delete(TEntity entity)
        => _dbSet.Remove(entity);

    public virtual void Update(TEntity entity)
        => _dbSet.Update(entity);

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);
}
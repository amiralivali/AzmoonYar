using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using MongoDB.Driver;

namespace AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;

public class ExceptionLogRepository(MongoContext context) : IExceptionLogRepository
{
    private IMongoCollection<ExceptionLog> Collection => context.ExceptionLogs;
    
    public async Task AddAsync(ExceptionLog exceptionLog, CancellationToken cancellationToken = default)
         => await Collection.InsertOneAsync(exceptionLog,options:null,cancellationToken);

    public async Task<ExceptionLog?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await Collection.Find(x=>x.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyList<ExceptionLog>> GetAllAsync(CancellationToken cancellationToken = default)
       => await Collection.Find(_=>true).SortByDescending(x=>x.CreatedAt).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<ExceptionLog>> GetRecentAsync(int count, CancellationToken cancellationToken = default)
        => await Collection.Find(_ => true).SortByDescending(x=>x.CreatedAt).Limit(count).ToListAsync(cancellationToken);
}
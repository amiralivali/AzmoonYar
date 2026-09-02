using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using MongoDB.Driver;

namespace AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;

public class ActivityLogRepository(MongoContext context) : IActivityLogRepository
{
    private  IMongoCollection<ActivityLog> Collection => context.ActivityLogs;
    
    public async Task<List<ActivityLog>> GetAllAsync(CancellationToken cancellationToken = default)
         => await Collection.Find(_=>true).ToListAsync(cancellationToken);

    public async Task<ActivityLog> GetByIdAsync(string id, CancellationToken cancellationToken = default)
         => await Collection.Find(x=>x.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task AddAsync(ActivityLog activityLog, CancellationToken cancellationToken = default)
         => await Collection.InsertOneAsync(activityLog, options: null, cancellationToken);
}
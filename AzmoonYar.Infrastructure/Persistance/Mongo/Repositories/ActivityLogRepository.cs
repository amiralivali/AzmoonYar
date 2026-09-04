using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using MongoDB.Driver;

namespace AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;

public class ActivityLogRepository(MongoContext context) : IActivityLogRepository
{
    private IMongoCollection<ActivityLog> Collection => context.ActivityLogs;

    public async Task<PagedResult<ActivityLog>> GetAllAsync(
        string? searchPhrase,
        EntityType? entityType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var filterBuilder = Builders<ActivityLog>.Filter;
        var filters = new List<FilterDefinition<ActivityLog>>();

        if (!string.IsNullOrWhiteSpace(searchPhrase))
        {
            filters.Add(
                filterBuilder.Regex(
                    x => x.Message,
                    new MongoDB.Bson.BsonRegularExpression(searchPhrase, "i")));
        }

        if (entityType.HasValue)
        {
            filters.Add(
            filterBuilder.Eq( x => x.EntityType, entityType));
        }

        var filter = filters.Count > 0
            ? filterBuilder.And(filters)
            : filterBuilder.Empty;

        var totalCount = await Collection
            .CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        var totalPages = (int)Math.Ceiling(
            totalCount / (double)pageSize);

        var logs = await Collection
            .Find(filter)
            .SortByDescending(x => x.CreatedAt)
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<ActivityLog>(
            logs,
            pageNumber,
            pageSize,
            (int)totalCount,
            totalPages);
    }

    public async Task<List<ActivityLog>> GetRecent(
        CancellationToken cancellationToken = default)
        => await Collection
            .Find(_ => true)
            .SortByDescending(x => x.CreatedAt)
            .Limit(5)
            .ToListAsync(cancellationToken);

    public async Task<ActivityLog> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default)
        => await Collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task AddAsync(
        ActivityLog activityLog,
        CancellationToken cancellationToken = default)
        => await Collection.InsertOneAsync(
            activityLog,
            options: null,
            cancellationToken);
}
using AzmoonYar.Application.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Specification.ActivityLog;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;
using MongoDB.Driver;

namespace AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;

public class ActivityLogRepository(MongoContext context) : IActivityLogRepository
{
    private IMongoCollection<ActivityLog> Collection => context.ActivityLogs;

    public async Task<PagedResult<ActivityLog>> GetAllAsync(ActivityLogQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken = default)
    {
        var pageNumber = queryFilterSpec.PageNumber;
        var pageSize = queryFilterSpec.PageSize;
        var filterBuilder = Builders<ActivityLog>.Filter;
        var filters = new List<FilterDefinition<ActivityLog>>();

        if (!string.IsNullOrWhiteSpace(queryFilterSpec.SearchPhase))
        {
            filters.Add(
                filterBuilder.Regex(
                    x => x.Message,
                    new MongoDB.Bson.BsonRegularExpression(queryFilterSpec.SearchPhase, "i")));
        }

        if (queryFilterSpec.EntityType.HasValue)
        {
            filters.Add(
            filterBuilder.Eq( x => x.EntityType, queryFilterSpec.EntityType));
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
    {
         return await Collection
            .Find(_ => true)
            .SortByDescending(x => x.CreatedAt)
            .Limit(5)
            .ToListAsync(cancellationToken);

    }

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
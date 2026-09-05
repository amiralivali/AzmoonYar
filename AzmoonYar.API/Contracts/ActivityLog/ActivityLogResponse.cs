namespace AzmoonYar.API.Contracts.ActivityLog;

public record ActivityLogResponse(string? Id, string Message, DateTimeOffset CreatedAt);
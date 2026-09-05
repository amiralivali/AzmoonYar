using AzmoonYar.API.Contracts.ActivityLog;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.DTOs.Question;

namespace AzmoonYar.API.Mappers;

public static class ActivityLogContractMapping
{
    public static GetActivityLogDto ToDto(this GetActivityLogRequest request)
    {
        return new GetActivityLogDto(
            request.SearchPhase,
            request.EntityType,
            request.PageNumber,
            request.PageSize);
    }
    public static PagedResult<ActivityLogResponse> ToResponse(this PagedResult<ActivityLogDto> dto)
        => new(dto.Items.Select(x => x.ToResponse()).ToList(),
            dto.PageNumber,
            dto.PageSize,
            dto.TotalCount,
            dto.TotalPages);

    public static ActivityLogResponse ToResponse(this ActivityLogDto dto)
       => new (dto.Id,dto.Message,dto.CreatedAt);
}
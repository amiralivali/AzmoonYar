using AzmoonYar.API.Contracts.ExceptionLog;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.ExceptionLog;

namespace AzmoonYar.API.Mappers;

public static class ExceptionLogContractMapping
{
    public static ExceptionLogResponse ToResponse(this ExceptionLogDto dto)
    {
        return new ExceptionLogResponse(
            dto.Id,
            dto.ExceptionType,
            dto.Message,
            dto.StackTrace,
            dto.Source,
            dto.RequestPath,
            dto.RequestMethod,
            dto.StatusCode,
            dto.CreatedAt);
    }
        
}
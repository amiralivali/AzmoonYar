using AzmoonYar.Application.DTOs.OptionalItem;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IOptionalItemService
{
    Task<OptionalItemDto> UpdateOptionalItemAsync(long id,
        UpdateOptionalItemDto dto,
        CancellationToken cancellationToken = default);
}
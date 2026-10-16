using AzmoonYar.Application.DTOs.OptionalItem;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IOptionalItemService
{
    Task<OptionalItemDto> AddOptionalItemAsync(long id,
        CreateOptionalItemDto dto,
        CancellationToken cancellationToken = default);
    
    Task<OptionalItemDto> UpdateOptionalItemAsync(long id,
        UpdateOptionalItemDto dto,
        CancellationToken cancellationToken = default);

    Task DeleteOptionalItemAsync(long id,
        CancellationToken cancellationToken = default);
}
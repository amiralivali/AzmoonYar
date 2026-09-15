using AzmoonYar.Application.DTOs.MatchingItem;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IMatchingItemService
{
    Task<List<MatchingItemDto>> AddMatchingItemsAsync(long id,
        List<CreateMatchingItemDto> items,
        CancellationToken cancellationToken = default);

    Task<List<MatchingItemDto>> UpdateMatchingItemsAsync(long id,
        List<UpdateMatchingItemDto> items,
        CancellationToken cancellationToken = default);

    Task DeleteMatchingItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default);
}
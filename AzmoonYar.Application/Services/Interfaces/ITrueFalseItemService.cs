using AzmoonYar.Application.DTOs.TrueFalseItem;

namespace AzmoonYar.Application.Services.Interfaces;

public interface ITrueFalseItemService
{
    Task<List<TrueFalseItemDto>> AddTrueFalseItemsAsync(long id,
        List<CreateTrueFalseItemDto> items,
        CancellationToken cancellationToken = default);

    Task<List<TrueFalseItemDto>> UpdateTrueFalseItemsAsync(long id,
        List<UpdateTrueFalseItemDto> items,
        CancellationToken cancellationToken = default);

    Task DeleteTrueFalseItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default);
}
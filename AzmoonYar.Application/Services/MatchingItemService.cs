using AzmoonYar.Application.DTOs.MatchingItem;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class MatchingItemService(IQuestionRepository repository)
{
    public async Task<List<MatchingItemDto>> AddMatchingItemsAsync(long id,
        List<CreateMatchingItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var results = items.Select(dto => ToDto(question.AddMatchingItem(dto.LeftItemText,dto.RightItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return results;
    }

    public async Task<List<MatchingItemDto>> UpdateMatchingItemsAsync(long id,
        List<UpdateMatchingItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var results = items.Select(dto => ToDto(question.UpdateMatchingItem(dto.Id,dto.LeftItemText,dto.RightItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return results;
    }

    public async Task DeleteMatchingItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveMatchingItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    private static MatchingItemDto ToDto(MatchingItem item) => new(
        item.Id,
        item.LeftItemText,
        item.RightItemText
    );
}
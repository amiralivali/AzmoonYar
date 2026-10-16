using AzmoonYar.Application.DTOs.MatchingItem;
using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services.implementations;

public class MatchingItemService(IQuestionRepository repository,
    IActivityLogService logService) : IMatchingItemService
{
    public async Task<List<MatchingItemDto>> AddMatchingItemsAsync(long id,
        List<CreateMatchingItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var results = items.Select(dto => ToDto(question.AddMatchingItem(dto.LeftItemText,dto.RightItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new MatchingItemCreatedLogData(question.Id.ToString()),question.UserId,cancellationToken);
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
        await logService.AddAsync(new MatchingItemUpdatedLogData(question.Id.ToString()),question.UserId,cancellationToken);
        return results;
    }

    public async Task DeleteMatchingItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveMatchingItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new MatchingItemDeletedLogData(question.Id.ToString()),question.UserId,cancellationToken);
    }
    
    private static MatchingItemDto ToDto(MatchingItem item) => new(
        item.Id,
        item.LeftItemText,
        item.RightItemText
    );
}
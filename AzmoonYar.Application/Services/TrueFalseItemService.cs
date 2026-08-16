using AzmoonYar.Application.Caching;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.DTOs.TrueFalseItem;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class TrueFalseItemService(IQuestionRepository repository, QuestionCache cacheService)
{
    public async Task<List<TrueFalseItemDto>> AddTrueFalseItemsAsync(long id,
        List<CreateTrueFalseItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var results = items.Select(dto => ToDto(question.AddTrueFalseItem(dto.ItemText,dto.IsCorrect))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return results;
    }

    public async Task<List<TrueFalseItemDto>> UpdateTrueFalseItemsAsync(long id,
        List<UpdateTrueFalseItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var results = items.Select(dto => ToDto(question.UpdateTrueFalseItem(dto.Id,dto.ItemText,dto.IdCorrect))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return results;
    }

    public async Task DeleteTrueFalseItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveTrueFalseItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }
    
    private static TrueFalseItemDto ToDto(TrueFalseItem item) => new(
        item.Id,
        item.ItemText,
        item.IsCorrect
    );
}
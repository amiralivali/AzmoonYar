using AzmoonYar.Application.Caching;
using AzmoonYar.Application.DTOs.OptionalItem;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class OptionalItemService(IQuestionRepository repository, QuestionCache cacheService)
{
    public async Task<OptionalItemDto> UpdateOptionalItemAsync(long id,
        UpdateOptionalItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateOptionalItem(dto.Id, dto.Option1,dto.Option2,dto.Option3,dto.Option4,dto.CorrectOption);
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return ToDto(item);
    }
    
    private static OptionalItemDto ToDto(OptionalItem item) => new(
        item.Id,
        item.Option1,
        item.Option2,
        item.Option3,
        item.Option4,
        item.CorrectOption
    );
}
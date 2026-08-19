using AzmoonYar.Application.DTOs.FillInBlankItem;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class FillInBlankItemService(IQuestionRepository repository)
{
    public async Task<List<FillInBlankItemDto>> AddFillInBlankItemsAsync(long id,
        List<CreateFillInBlankItemDto> items,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ??  throw new EntityNotFoundException(nameof(Question), id);
        var result = items.Select(dto => ToDto(question.AddFillInBlankItem(dto.ItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<FillInBlankItemDto>> UpdateFillInBlankItemsAsync(long id,
        List<UpdateFillInBlankItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.UpdateFillInBlankItem(dto.Id,dto.ItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return items;
    }

    public async Task DeleteFillInBlankItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveFillInBlankItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<FillInBlankAnswerDto>> AddFillInBlankAnswersAsync(long itemId,
        List<CreateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        var answers = fillInBlankAnswers
            .Select(dto => ToDto(item.AddAnswer(dto.Answer))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return answers;
    }
    
    public async Task<List<FillInBlankAnswerDto>> UpdateFillInBlankAnswersAsync(long itemId,
        List<UpdateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        var answers = fillInBlankAnswers
            .Select(dto => ToDto(item.UpdateAnswer(dto.Id,dto.Answer))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        return answers;
    }
    
    public async Task DeleteFillInBlankAnswerAsync(long itemId, long answerId,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        item.DeleteAnswer(answerId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    private static FillInBlankItemDto ToDto(FillInBlankItem item) => new(
        item.Id,
        item.ItemText
    );
    
    private static FillInBlankAnswerDto ToDto(FillInBlankAnswer item) => new(
        item.Id,
        item.Answer
    );
}
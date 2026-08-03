using AzmoonYar.Application.CacheKeys;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class QuestionService(IQuestionRepository repository)
{
    public async Task<QuestionDto> AddAsync(CreateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question = new Question(dto.LessonId, dto.QuestionText, dto.DifficultyLevel, dto.QuestionType);
        question.ChangePicture(dto.Picture);
        switch (dto.QuestionType)
        {
            case QuestionType.FillInBlank:
                foreach (var item in dto.FillInBlankItems)
                {
                    question.AddFillInBlankItem(item.ItemText);
                }
                break;
            case QuestionType.Matching:
                foreach (var item in dto.MatchingItems)
                {
                    question.AddMatchingItem(item.LeftItemText, item.RightItemText);
                }
                break;
            case QuestionType.TrueFalse:
                foreach (var item in dto.TrueFalseItems)
                {
                    question.AddTrueFalseItem(item.ItemText);
                }
                break;
            case QuestionType.Optional:
                ArgumentNullException.ThrowIfNull(dto.OptionalItem);
                question.AddOptionalItem(
                    dto.OptionalItem.Option1,
                    dto.OptionalItem.Option2,
                    dto.OptionalItem.Option3,
                    dto.OptionalItem.Option4);
                break;
        } 
        await repository.AddAsync(question,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(question);
    }
    public async Task<QuestionDto> UpdateAsync(long id, UpdateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question =  await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        question.UpdateQuestion(dto.LessonId,dto.QuestionText,dto.DifficultyLevel,dto.QuestionType);
        question.ChangePicture(dto.Picture);
        switch (question.QuestionType)
        {
            case QuestionType.FillInBlank:
                foreach (var item in dto.FillInBlankItems)
                {
                    question.UpdateFillInBlankItem(item.Id,item.ItemText);
                }
                break;
            case QuestionType.Matching:
                foreach (var item in dto.MatchingItems)
                {
                    question.UpdateMatchingItem(item.Id,item.LeftItemText, item.RightItemText);
                }
                break;
            case QuestionType.TrueFalse:
                foreach (var item in dto.TrueFalseItems)
                {
                    question.UpdateTrueFalseItem(item.Id,item.ItemText);
                }
                break;
            case QuestionType.Optional:
                ArgumentNullException.ThrowIfNull(dto.OptionalItem);
                question.UpdateOptionalItem(dto.OptionalItem.Id,
                    dto.OptionalItem.Option1,
                    dto.OptionalItem.Option2,
                    dto.OptionalItem.Option3,
                    dto.OptionalItem.Option4);
                break;
        } 
        repository.Update(question);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(question);
    }

    public async Task<QuestionDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        
        return ToDto(question);
    }
    public async Task<IReadOnlyList<QuestionDto>> GetAllAsync
        (QuestionType questionType,CancellationToken cancellationToken = default)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values.Select(ToDto).ToList();
    }
    
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        repository.Delete(question);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task ChangePicture(long id, string picture, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ??  throw new EntityNotFoundException(nameof(Question), id);
        question.ChangePicture(picture);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<FillInBlankItemDto> AddFillInBlankItemAsync(long id,
        CreateFillInBlankItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ??  throw new EntityNotFoundException(nameof(Question), id);
        var item = question.AddFillInBlankItem(dto.ItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task<FillInBlankItemDto> UpdateFillInBlankItemAsync(long id,
        UpdateFillInBlankItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateFillInBlankItem(dto.Id, dto.ItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task DeleteFillInBlankItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveFillInBlankItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<TrueFalseItemDto> AddTrueFalseItemAsync(long id,
        CreateTrueFalseItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var item = question.AddTrueFalseItem(dto.ItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task<TrueFalseItemDto> UpdateTrueFalseItemAsync(long id,
        UpdateTrueFalseItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateTrueFalseItem(dto.Id, dto.ItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task DeleteTrueFalseItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveTrueFalseItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<MatchingItemDto> AddMatchingItemAsync(long id,
        CreateMatchingItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var item = question.AddMatchingItem(dto.LeftItemText,dto.RightItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task<MatchingItemDto> UpdateMatchingItemAsync(long id,
        UpdateMatchingItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateMatchingItem(dto.Id, dto.LeftItemText,dto.RightItemText);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }

    public async Task DeleteMatchingItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveMatchingItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<OptionalItemDto> UpdateOptionalItemAsync(long id,
        UpdateOptionalItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateOptionalItem(dto.Id, dto.Option1,dto.Option2,dto.Option3,dto.Option4);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(item);
    }
    
    private static QuestionDto ToDto(Question question) => new(
        question.Id,
        question.LessonId,
        question.QuestionText,
        question.Picture,
        question.DifficultyLevel,
        question.QuestionType,
        question.CreatedAt,

        question.OptionalItem is null
            ? null
            : new OptionalItemDto(
                question.OptionalItem.Id,
                question.OptionalItem.Option1,
                question.OptionalItem.Option2,
                question.OptionalItem.Option3,
                question.OptionalItem.Option4),

        question.TrueFalseItems
            .Select(x => new TrueFalseItemDto(x.Id, x.ItemText))
            .ToList(),

        question.MatchingItems
            .Select(x => new MatchingItemDto(x.Id, x.LeftItemText, x.RightItemText))
            .ToList(),

        question.FillInBlankItems
            .Select(x => new FillInBlankItemDto(x.Id, x.ItemText))
            .ToList()
    );

    private static FillInBlankItemDto ToDto(FillInBlankItem item) => new(
        item.Id,
        item.ItemText
    );
    
    private static TrueFalseItemDto ToDto(TrueFalseItem item) => new(
        item.Id,
        item.ItemText
    );
    
    private static MatchingItemDto ToDto(MatchingItem item) => new(
        item.Id,
        item.LeftItemText,
        item.RightItemText
    );
    
    private static OptionalItemDto ToDto(OptionalItem item) => new(
        item.Id,
        item.Option1,
        item.Option2,
        item.Option3,
        item.Option4
    );
}
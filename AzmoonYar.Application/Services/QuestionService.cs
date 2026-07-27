using AzmoonYar.Application.DTOs.Question;
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

    public async Task<QuestionDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        
        return ToDto(question);
    }
    
    public async Task<IReadOnlyList<QuestionDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var questions = await repository.GetAllAsync(cancellationToken);
        return questions.Select(ToDto).ToList();
    }
    
    public async Task<IReadOnlyList<QuestionDto>> GetAllAsync(QuestionType questionType,CancellationToken cancellationToken = default)
    {
        var questions = await repository.GetAllAsync(questionType,cancellationToken);
        return questions.Select(ToDto).ToList();
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        repository.Delete(question);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteItemAsync(long questionId,long itemId = 0, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(questionId, cancellationToken) 
            ?? throw new EntityNotFoundException(nameof(Question), questionId);
        switch (question.QuestionType)
        {
            case QuestionType.FillInBlank:
                question.RemoveFillInBlankItem(itemId);
                break;  
            case QuestionType.TrueFalse:
                question.RemoveTrueFalseItem(itemId);
                break;  
            case QuestionType.Matching:
                question.RemoveMatchingItem(itemId);
                break;  
            case QuestionType.Optional:
                throw new WrongRequestForDeleteOptionalItem();
            case QuestionType.Descriptive:
                throw new DescriptiveQuestionWithoutItemException();
            case QuestionType.ShortAnswer:
                throw new ShortAnswerQuestionWithoutItemException();
        }
        await repository.SaveChangesAsync(cancellationToken);
    }
    
    public async Task DeleteOptionalItemAsync(
        long questionId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(questionId, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), questionId);

        question.RemoveOptionalItem();

        await repository.SaveChangesAsync(cancellationToken);
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
    
}
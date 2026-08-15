using AzmoonYar.Application.Caching;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class QuestionService(IQuestionRepository repository,QuestionCache cacheService)
{
    public async Task<QuestionDto> AddQuestionAsync(CreateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question = new Question(dto.LessonId, dto.QuestionText, dto.DifficultyLevel, dto.QuestionType);
        question.ChangePicture(dto.Picture);
        await repository.AddAsync(question,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return ToDto(question);
    }
    public async Task<QuestionDto> UpdateQuestionAsync(long id, UpdateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question =  await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        var oldType = question.QuestionType;
        var oldLessonId = question.LessonId;
        question.UpdateQuestion(dto.LessonId,dto.QuestionText,dto.DifficultyLevel,dto.QuestionType);
        question.ChangePicture(dto.Picture);
        repository.Update(question);
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(
            oldType,
            question.Id,
            oldLessonId,
            cancellationToken);
        await cacheService.InvalidateAsync(
            question.QuestionType,
            question.Id,
            question.LessonId,
            cancellationToken);
        return ToDto(question);
    }

    public async Task<QuestionDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await cacheService.GetByIdAsync(id,
            async ct => ToDto(await repository.GetByIdAsync(id, ct) ??
                              throw new EntityNotFoundException(nameof(Question), id)),
            cancellationToken);

    public async Task<IReadOnlyList<QuestionDto>> GetAllByQuestionTypeAsync
        (QuestionType questionType, CancellationToken cancellationToken = default)
        => await cacheService.GetAllByQuestionTypeAsync(questionType,
            async ct => (await repository.GetAllByQuestionTypeAsync(questionType, ct)).Select(ToDto).ToList(),
            cancellationToken);
    
    public async Task<IReadOnlyList<QuestionDto>> GetAllAsync
        (CancellationToken cancellationToken = default)
        => await cacheService.GetAllAsync(async ct => (await repository.GetAllAsync(ct)).Select(ToDto).ToList(),
            cancellationToken);
    
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        repository.Delete(question);
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }

    public async Task ChangePicture(long id, string picture, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ??  throw new EntityNotFoundException(nameof(Question), id);
        question.ChangePicture(picture);
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }

    public async Task<List<FillInBlankItemDto>> AddFillInBlankItemAsync(long id,
        List<CreateFillInBlankItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ??  throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.AddFillInBlankItem(dto.ItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);

        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
    }

    public async Task<List<FillInBlankItemDto>> UpdateFillInBlankItemAsync(long id,
        List<UpdateFillInBlankItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.UpdateFillInBlankItem(dto.Id,dto.ItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
    }

    public async Task DeleteFillInBlankItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveFillInBlankItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }
    
    public async Task<List<FillInBlankAnswerDto>> AddFillInBlankAnswersAsync(long itemId,
        List<CreateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        var question = await repository.GetByIdAsync(item.FillInBlankQuestionId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), item.FillInBlankQuestionId);
        var answers = fillInBlankAnswers
            .Select(dto => ToDto(item.AddAnswer(dto.Answer))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return answers;
    }
    
    public async Task<List<FillInBlankAnswerDto>> UpdateFillInBlankAnswerAsync(long itemId,
        List<UpdateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        var question = await repository.GetByIdAsync(item.FillInBlankQuestionId, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), item.FillInBlankQuestionId);
        var answers = fillInBlankAnswers
            .Select(dto => ToDto(item.UpdateAnswer(dto.Id,dto.Answer))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return answers;
    }
    
    public async Task DeleteFillInBlankAnswerAsync(long itemId, long answerId,
        CancellationToken cancellationToken = default)
    {
        var item = await repository.GetFillInBlankItemByIdAsync(itemId, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        var question = await repository.GetByIdAsync(item.FillInBlankQuestionId, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), item.FillInBlankQuestionId);
        item.DeleteAnswer(answerId);
        await repository.SaveChangesAsync(cancellationToken);
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }
    
    public async Task<List<TrueFalseItemDto>> AddTrueFalseItemAsync(long id,
        List<CreateTrueFalseItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.AddTrueFalseItem(dto.ItemText,dto.IsCorrect))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
    }

    public async Task<List<TrueFalseItemDto>> UpdateTrueFalseItemAsync(long id,
        List<UpdateTrueFalseItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.UpdateTrueFalseItem(dto.Id,dto.ItemText,dto.IdCorrect))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
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
    
    public async Task<List<MatchingItemDto>> AddMatchingItemAsync(long id,
        List<CreateMatchingItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ??  throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.AddMatchingItem(dto.LeftItemText,dto.RightItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
    }

    public async Task<List<MatchingItemDto>> UpdateMatchingItemAsync(long id,
        List<UpdateMatchingItemDto> dtos,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var items = dtos.Select(dto => ToDto(question.UpdateMatchingItem(dto.Id,dto.LeftItemText,dto.RightItemText))).ToList();
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
        return items;
    }

    public async Task DeleteMatchingItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveMatchingItem(itemId);
        await repository.SaveChangesAsync(cancellationToken);
        
        await cacheService.InvalidateAsync(question.QuestionType, question.Id, question.LessonId, cancellationToken);
    }
    
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

    public async Task<int> GetQuestionsCountByLessonIdAsync(long lessonId,
        CancellationToken cancellationToken = default)
        => await cacheService.GetQuestionsCountByLessonIdAsync(lessonId,
            async ct => await repository.GetQuestionsCountByLessonIdAsync(lessonId, ct),
            cancellationToken);

    private static QuestionDto ToDto(Question question)
    {
        OptionalItemDto? optionalItem = null;
        var fillInBlankItems = new List<FillInBlankItemDto>();
        var fillInBlankAnswers = new List<FillInBlankAnswerDto>();
        var trueFalseItems = new List<TrueFalseItemDto>();
        var matchingItems = new List<MatchingItemDto>();

        switch (question.QuestionType)
        {
            case QuestionType.Optional:
                if (question.OptionalItem is null)
                    throw new InvalidOperationException(
                        $"Optional item not found for question {question.Id}");

                optionalItem = ToDto(question.OptionalItem);
                break;

            case QuestionType.FillInBlank:
                fillInBlankItems = question.FillInBlankItems
                    .Select(ToDto)
                    .ToList();

                fillInBlankAnswers = question.FillInBlankItems
                    .SelectMany(x => x.Answers)
                    .Select(ToDto)
                    .ToList();
                break;

            case QuestionType.TrueFalse:
                trueFalseItems = question.TrueFalseItems
                    .Select(ToDto)
                    .ToList();
                break;

            case QuestionType.Matching:
                matchingItems = question.MatchingItems
                    .Select(ToDto)
                    .ToList();
                break;

            case QuestionType.Descriptive:
            case QuestionType.ShortAnswer:
                break;

            default:
                throw new InvalidQuestionType();
        }

        return new QuestionDto(
            question.Id,
            question.LessonId,
            question.QuestionText,
            question.Picture,
            question.DifficultyLevel,
            question.QuestionType,
            question.CreatedAt,
            optionalItem,
            fillInBlankItems,
            fillInBlankAnswers,
            trueFalseItems,
            matchingItems
        );
    }

    private static FillInBlankItemDto ToDto(FillInBlankItem item) => new(
        item.Id,
        item.ItemText
    );
    
    private static FillInBlankAnswerDto ToDto(FillInBlankAnswer item) => new(
        item.Id,
        item.Answer
    );
    
    private static TrueFalseItemDto ToDto(TrueFalseItem item) => new(
        item.Id,
        item.ItemText,
        item.IsCorrect
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
        item.Option4,
        item.CorrectOption
    );
}
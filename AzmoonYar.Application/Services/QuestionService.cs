using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.DTOs.FillInBlankItem;
using AzmoonYar.Application.DTOs.MatchingItem;
using AzmoonYar.Application.DTOs.OptionalItem;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.DTOs.TrueFalseItem;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class QuestionService(IQuestionRepository repository)
{
    public async Task<QuestionDto> AddQuestionAsync(CreateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question = new Question(dto.LessonId, dto.QuestionText, dto.DifficultyLevel, dto.QuestionType);
        question.ChangePicture(dto.Picture);
        await repository.AddAsync(question,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return ToDto(question);
    }
    public async Task<QuestionDto> UpdateQuestionAsync(long id, UpdateQuestionDto dto,CancellationToken cancellationToken = default)
    {
        var question =  await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Question), id);
        question.UpdateQuestion(dto.LessonId,dto.QuestionText,dto.DifficultyLevel,dto.QuestionType);
        question.ChangePicture(dto.Picture);
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

    public async Task<PagedResult<QuestionDto>> GetAllAsync(
        GetQuestionDto request,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(request.Filter.SearchPhase,request.Filter.BookId,
            request.Filter.LessonId,request.Filter.DifficultyLevel,
            request.Filter.Grade,request.Filter.QuestionType,
            request.PaginationFilter.PageNumber,request.PaginationFilter.PageSize
                ,cancellationToken);
        return ToDto(result);
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

    public async Task<int> GetQuestionsCountByLessonIdAsync(long lessonId,
        CancellationToken cancellationToken = default)
    {
        return await repository.GetQuestionsCountByLessonIdAsync(lessonId, cancellationToken);
    }

    private static PagedResult<QuestionDto> ToDto(PagedResult<Question> result)
         => new (result.Items.Select(ToDto).ToList(),
             result.PageNumber,
             result.PageSize,
             result.TotalCount,
             result.TotalPages);
    
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

                optionalItem = new OptionalItemDto(
                    question.OptionalItem.Id,
                    question.OptionalItem.Option1,
                    question.OptionalItem.Option2,
                    question.OptionalItem.Option3,
                    question.OptionalItem.Option4,
                    question.OptionalItem.CorrectOption);
                break;

            case QuestionType.FillInBlank:
                fillInBlankItems = question.FillInBlankItems
                    .Select(x=> new FillInBlankItemDto(x.Id,x.ItemText))
                    .ToList();

                fillInBlankAnswers = question.FillInBlankItems
                    .SelectMany(x => x.Answers)
                    .Select(x=> new FillInBlankAnswerDto(x.Id,x.Answer))
                    .ToList();
                break;

            case QuestionType.TrueFalse:
                trueFalseItems = question.TrueFalseItems
                    .Select(x=> new TrueFalseItemDto(x.Id, x.ItemText, x.IsCorrect))
                    .ToList();
                break;

            case QuestionType.Matching:
                matchingItems = question.MatchingItems
                    .Select(x=> new MatchingItemDto(x.Id,x.LeftItemText,x.RightItemText))
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
}
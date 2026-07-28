using AzmoonYar.API.Contracts.Question;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Mappers;

public static class QuestionContractMapping
{
    public static CreateQuestionDto ToDto(this CreateDescriptiveQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Descriptive,
            request.DifficultyLevel);
    }
    public static CreateQuestionDto ToDto(this CreateShortAnswerQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.ShortAnswer,
            request.DifficultyLevel);
    }
    public static CreateQuestionDto ToDto(this CreateTrueFalseQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.TrueFalse,
            request.DifficultyLevel,
            TrueFalseItems: request.TrueFalseItems.Select(x=>new CreateTrueFalseItemDto(x.ItemText)).ToList());
    }
    public static CreateQuestionDto ToDto(this CreateFillInBlankQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.FillInBlank,
            request.DifficultyLevel,
            FillInBlankItems: request.FillInBlankItems.Select(x=>new CreateFillInBlankItemDto(x.ItemText)).ToList());
    }
    public static CreateQuestionDto ToDto(this CreateMatchingQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Matching,
            request.DifficultyLevel,
            MatchingItems: request.MatchingItems.Select(x=>new CreateMatchingItemDto(x.LeftItemText,x.RightItemText)).ToList());
    }
    public static CreateQuestionDto ToDto(this CreateOptionalQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Optional,
            request.DifficultyLevel,
            OptionalItem: new CreateOptionalItemDto(request.OptionalItem.Option1, request.OptionalItem.Option2, request.OptionalItem.Option3, request.OptionalItem.Option4));
    }

    public static QuestionResponse ToResponse(this QuestionDto dto)=> new(
        dto.QuestionId,
        dto.LessonId,
        dto.QuestionText,
        dto.Picture,
        dto.DifficultyLevel,
        dto.QuestionType,
        dto.CreatedAt,

        dto.OptionalItem is null
            ? null
            : new OptionalItemResponse(
                dto.OptionalItem.Id,
                dto.OptionalItem.Option1,
                dto.OptionalItem.Option2,
                dto.OptionalItem.Option3,
                dto.OptionalItem.Option4),

        dto.TrueFalseItems
            .Select(x => new TrueFalseItemResponse(x.Id, x.ItemText))
            .ToList(),

        dto.MatchingItems
            .Select(x => new MatchingItemResponse(x.Id, x.LeftItemText, x.RightItemText))
            .ToList(),

        dto.FillInBlankItems
            .Select(x => new FillInBlankItemResponse(x.Id, x.ItemText))
            .ToList()
    );
    public static UpdateQuestionDto ToDto(this UpdateDescriptiveQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Descriptive,
            request.DifficultyLevel);
    }
    public static UpdateQuestionDto ToDto(this UpdateShortAnswerQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.ShortAnswer,
            request.DifficultyLevel);
    }
    public static UpdateQuestionDto ToDto(this UpdateTrueFalseQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.TrueFalse,
            request.DifficultyLevel,
            TrueFalseItems: request.TrueFalseItems.Select(x=>new UpdateTrueFalseItemDto(x.Id,x.ItemText)).ToList());
    }
    public static UpdateQuestionDto ToDto(this UpdateFillInBlankQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.FillInBlank,
            request.DifficultyLevel,
            FillInBlankItems: request.FillInBlankItems.Select(x=>new UpdateFillInBlankItemDto(x.Id,x.ItemText)).ToList());
    }
    public static UpdateQuestionDto ToDto(this UpdateMatchingQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Matching,
            request.DifficultyLevel,
            MatchingItems: request.MatchingItems.Select(x=>new UpdateMatchingItemDto(x.Id,x.LeftItemText,x.RightItemText)).ToList());
    }
    public static UpdateQuestionDto ToDto(this UpdateOptionalQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            QuestionType.Optional,
            request.DifficultyLevel,
            OptionalItem: new UpdateOptionalItemDto(request.OptionalItem.Id,request.OptionalItem.Option1, request.OptionalItem.Option2, request.OptionalItem.Option3, request.OptionalItem.Option4));
    }
}
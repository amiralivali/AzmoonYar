using AzmoonYar.API.Contracts.Question;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Mappers;

public static class QuestionContractMapping
{
    public static CreateFillInBlankItemDto ToDto(this CreateFillInBlankItemRequest request)
    {
        return new CreateFillInBlankItemDto(request.ItemText);
    }
    
    public static UpdateFillInBlankItemDto ToDto(this UpdateFillInBlankItemRequest request)
    {
        return new UpdateFillInBlankItemDto(request.Id,request.ItemText);
    }
    
    public static FillInBlankItemResponse ToResponse(this FillInBlankItemDto dto)
    {
        return new FillInBlankItemResponse(dto.Id,dto.ItemText);
    }
    
    public static CreateTrueFalseItemDto ToDto(this CreateTrueFalseItemRequest request)
    {
        return new CreateTrueFalseItemDto(request.ItemText);
    }
    
    public static UpdateTrueFalseItemDto ToDto(this UpdateTrueFalseItemRequest request)
    {
        return new UpdateTrueFalseItemDto(request.Id,request.ItemText);
    }
    
    public static TrueFalseItemResponse ToResponse(this TrueFalseItemDto dto)
    {
        return new TrueFalseItemResponse(dto.Id,dto.ItemText);
    }
    
    public static CreateMatchingItemDto ToDto(this CreateMatchingItemRequest request)
    {
        return new CreateMatchingItemDto(request.LeftItemText,request.RightItemText);
    }
    
    public static UpdateMatchingItemDto ToDto(this UpdateMatchingItemRequest request)
    {
        return new UpdateMatchingItemDto(request.Id,request.LeftItemText,request.RightItemText);
    }
    
    public static MatchingItemResponse ToResponse(this MatchingItemDto dto)
    {
        return new MatchingItemResponse(dto.Id,dto.LeftItemText,dto.RightItemText);
    }

    private static CreateOptionalItemDto ToDto(this CreateOptionalItemRequest request)
    {
        return new CreateOptionalItemDto(request.Option1,request.Option2,request.Option3,request.Option4);
    }
    
    public static UpdateOptionalItemDto ToDto(this UpdateOptionalItemRequest request)
    {
        return new UpdateOptionalItemDto(request.Id,request.Option1,request.Option2,request.Option3,request.Option4);
    }
    
    public static OptionalItemResponse ToResponse(this OptionalItemDto dto)
    {
        return new OptionalItemResponse(dto.Id,dto.Option1,dto.Option2,dto.Option3,dto.Option4);
    }

    public static CreateQuestionDto ToDto(this CreateQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            request.QuestionType,
            request.DifficultyLevel,

            request.OptionalItem?.ToDto(),

            request.TrueFalseItems
                .Select(x => x.ToDto())
                .ToList(),

            request.MatchingItems
                .Select(x => x.ToDto())
                .ToList(),

            request.FillInBlankItems
                .Select(x => x.ToDto())
                .ToList());
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
}
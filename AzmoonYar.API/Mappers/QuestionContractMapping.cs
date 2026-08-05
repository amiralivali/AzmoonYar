using AzmoonYar.API.Contracts.Question;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Mappers;

public static class QuestionContractMapping
{
    public static List<CreateFillInBlankItemDto> ToDto(this List<CreateFillInBlankItemRequest> request)
    {
        return request.Select(x => new CreateFillInBlankItemDto(x.ItemText)).ToList();
    }
    
    public static List<UpdateFillInBlankItemDto> ToDto(this List<UpdateFillInBlankItemRequest> request)
    {
        return request.Select(x => new UpdateFillInBlankItemDto(x.Id,x.ItemText)).ToList();
    }
    
    public static List<FillInBlankItemResponse> ToResponse(this List<FillInBlankItemDto> dto)
    {
        return dto.Select(x => new FillInBlankItemResponse(x.Id, x.ItemText)).ToList();
    }
    
    public static List<CreateTrueFalseItemDto> ToDto(this List<CreateTrueFalseItemRequest> request)
    {
        return request.Select(x => new CreateTrueFalseItemDto(x.ItemText)).ToList();
    }
    
    public static List<UpdateTrueFalseItemDto> ToDto(this List<UpdateTrueFalseItemRequest> request)
    {
        return request.Select(x => new UpdateTrueFalseItemDto(x.Id,x.ItemText)).ToList();
    }
    
    public static List<TrueFalseItemResponse> ToResponse(this List<TrueFalseItemDto> dto)
    {
        return dto.Select(x => new TrueFalseItemResponse(x.Id,x.ItemText)).ToList();
    }
    
    public static List<CreateMatchingItemDto> ToDto(this List<CreateMatchingItemRequest> request)
    {
        return request.Select(x => new CreateMatchingItemDto(x.LeftItemText,x.RightItemText)).ToList();
    }
    
    public static List<UpdateMatchingItemDto> ToDto(this List<UpdateMatchingItemRequest> request)
    {
        return request.Select(x => new UpdateMatchingItemDto(x.Id,x.LeftItemText,x.RightItemText)).ToList();
    }
    
    public static List<MatchingItemResponse> ToResponse(this List<MatchingItemDto> dto)
    {
        return dto.Select(x => new MatchingItemResponse(x.Id,x.LeftItemText,x.RightItemText)).ToList();
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
            request.DifficultyLevel);
    }
    
    public static QuestionResponse ToResponse(this QuestionDto dto)=> new(
        dto.QuestionId,
        dto.LessonId,
        dto.QuestionText,
        dto.Picture,
        dto.DifficultyLevel,
        dto.QuestionType,
        dto.CreatedAt
    );
}
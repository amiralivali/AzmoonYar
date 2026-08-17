using AzmoonYar.API.Contracts.FillInBlankItem;
using AzmoonYar.API.Contracts.MatchingItem;
using AzmoonYar.API.Contracts.OptionalItem;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Contracts.TrueFalseItem;
using AzmoonYar.Application.DTOs.FillInBlankItem;
using AzmoonYar.Application.DTOs.MatchingItem;
using AzmoonYar.Application.DTOs.OptionalItem;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.DTOs.TrueFalseItem;
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
    public static List<CreateFillInBlankAnswerDto> ToDto(this List<CreateFillInBlankAnswerRequest> request)
    {
        return request.Select(x => new CreateFillInBlankAnswerDto(x.Answer)).ToList();
    }
    
    public static List<UpdateFillInBlankAnswerDto> ToDto(this List<UpdateFillInBlankAnswerRequest> request)
    {
        return request.Select(x => new UpdateFillInBlankAnswerDto(x.Id,x.Answer)).ToList();
    }
    
    public static List<FillInBlankAnswerResponse> ToResponse(this List<FillInBlankAnswerDto> dto)
    {
        return dto.Select(x => new FillInBlankAnswerResponse(x.Id, x.Answer)).ToList();
    }
    
    public static List<CreateTrueFalseItemDto> ToDto(this List<CreateTrueFalseItemRequest> request)
    {
        return request.Select(x => new CreateTrueFalseItemDto(x.ItemText,x.IsCorrect)).ToList();
    }
    
    public static List<UpdateTrueFalseItemDto> ToDto(this List<UpdateTrueFalseItemRequest> request)
    {
        return request.Select(x => new UpdateTrueFalseItemDto(x.Id,x.ItemText,x.IsCorrect)).ToList();
    }
    
    public static List<TrueFalseItemResponse> ToResponse(this List<TrueFalseItemDto> dto)
    {
        return dto.Select(x => new TrueFalseItemResponse(x.Id,x.ItemText,x.IsCorrect)).ToList();
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
        return new CreateOptionalItemDto(request.Option1,request.Option2,request.Option3,request.Option4,request.CorrectOption);
    }
    
    public static UpdateOptionalItemDto ToDto(this UpdateOptionalItemRequest request)
    {
        return new UpdateOptionalItemDto(request.Id,request.Option1,request.Option2,request.Option3,request.Option4,request.CorrectOption);
    }
    
    public static OptionalItemResponse ToResponse(this OptionalItemDto dto)
    {
        return new OptionalItemResponse(dto.Id,dto.Option1,dto.Option2,dto.Option3,dto.Option4,dto.CorrectOption);
    }

    public static CreateQuestionDto ToDto(this CreateQuestionRequest request)
    {
        return new CreateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            request.QuestionType,
            request.DifficultyLevel);
    }
    
    public static UpdateQuestionDto ToDto(this UpdateQuestionRequest request)
    {
        return new UpdateQuestionDto(request.LessonId,
            request.QuestionText,
            request.Picture,
            request.QuestionType,
            request.DifficultyLevel);
    }

    public static QuestionListFilterDto ToDto(this QuestionListFilter filter)
        => new QuestionListFilterDto(filter.SearchPhase,
            filter.BookId,
            filter.LessonId,
            filter.DifficultyLevel,
            filter.Grade,
            filter.QuestionType);
    
    
    public static QuestionResponse ToResponse(this QuestionDto dto)
    {
        OptionalItemResponse? optionalItem = null;
        var fillInBlankItems = new List<FillInBlankItemResponse>();
        var fillInBlankAnswers = new List<FillInBlankAnswerResponse>();
        var trueFalseItems = new List<TrueFalseItemResponse>();
        var matchingItems = new List<MatchingItemResponse>();

        switch (dto.QuestionType)
        {
            case QuestionType.Optional:
                if (dto.OptionalItem is null)
                    throw new InvalidOperationException(
                        $"Optional item not found for question {dto.QuestionId}");

                optionalItem = dto.OptionalItem.ToResponse();
                break;

            case QuestionType.FillInBlank:
                fillInBlankItems = dto.FillInBlankItems
                    .ToResponse();

                fillInBlankAnswers = dto.FillInBlankAnswers
                    .ToResponse();
                break;

            case QuestionType.TrueFalse:
                trueFalseItems = dto.TrueFalseItems
                    .ToResponse();
                break;

            case QuestionType.Matching:
                matchingItems = dto.MatchingItems
                    .ToResponse();
                break;

            case QuestionType.Descriptive:
            case QuestionType.ShortAnswer:
                break;
        }

        return new QuestionResponse(
            dto.QuestionId,
            dto.LessonId,
            dto.QuestionText,
            dto.Picture,
            dto.DifficultyLevel,
            dto.QuestionType,
            dto.CreatedAt,
            optionalItem,
            fillInBlankItems,
            fillInBlankAnswers,
            trueFalseItems,
            matchingItems
        );
    }
}
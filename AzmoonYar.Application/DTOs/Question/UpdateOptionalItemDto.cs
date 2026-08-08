using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record UpdateOptionalItemDto(long Id,string Option1,
    string Option2,
    string Option3, 
    string Option4,
    OptionNumber CorrectOption);
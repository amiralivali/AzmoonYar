using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.OptionalItem;

public record CreateOptionalItemDto(string Option1,
    string Option2,
    string Option3, 
    string Option4,
    OptionNumber CorrectOption);
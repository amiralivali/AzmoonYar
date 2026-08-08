namespace AzmoonYar.Application.DTOs.Question;

public record TrueFalseItemDto(long Id,
    string ItemText,
    bool IsCorrect);
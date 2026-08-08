namespace AzmoonYar.API.Contracts.Question;

public record TrueFalseItemResponse(long Id,
    string ItemText,
    bool IsCorrect);
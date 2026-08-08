namespace AzmoonYar.API.Contracts.Question;

public record UpdateTrueFalseItemRequest(long Id, string ItemText,  bool IsCorrect);
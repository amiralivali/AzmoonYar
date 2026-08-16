namespace AzmoonYar.API.Contracts.TrueFalseItem;

public record UpdateTrueFalseItemRequest(long Id, string ItemText,  bool IsCorrect);
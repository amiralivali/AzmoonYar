using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.OptionalItem;

public record OptionalItemResponse(long Id,
    string Option1,
    string Option2,
    string Option3,
    string Option4,
    OptionNumber CorrectOption);
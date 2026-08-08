using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateOptionalItemRequest(
    long Id,
    string Option1,
    string Option2,
    string Option3,
    string Option4,
    OptionNumber CorrectOption);
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Dashboard;

public record QuestionTypeCountResponse(QuestionType QuestionType, int QuestionCount);
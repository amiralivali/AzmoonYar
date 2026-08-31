using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Dashboard;

public record QuestionTypeCountDto(QuestionType QuestionType, int QuestionCount);
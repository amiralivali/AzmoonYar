using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record CreateExamQuestionTypeDto(QuestionType QuestionType,
    int Count);
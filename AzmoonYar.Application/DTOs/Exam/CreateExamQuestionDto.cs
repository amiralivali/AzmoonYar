namespace AzmoonYar.Application.DTOs.Exam;

public record CreateExamQuestionDto(long QuestionId,
      decimal Score,
      bool ShuffleOptions);
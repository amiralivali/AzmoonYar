using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record CreateManualExamDto(
    long BookId,
    List<long> LessonIds,
    ExamType ExamType,
    ExamDifficultyLevel DifficultyLevel,
    ExamHeaderDto ExamHeader,
    List<CreateExamQuestionDto> Questions,
    List<CreateExamQuestionTypeDto> QuestionTypes);
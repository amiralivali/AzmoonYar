using AzmoonYar.Application.DTOs.Book;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record CreateExamDto(
    long BookId,
    List<long> LessonIds,
    string? HeaderPicture,
    string? HeaderText,
    string? LogoPicture,
    ICollection<LessonDto> Lessons,
    ExamType ExamType,
    DifficultyLevel DifficultyLevel,
    List<CreateExamQuestionDto> Questions,
    List<CreateExamQuestionTypeDto> QuestionTypes);
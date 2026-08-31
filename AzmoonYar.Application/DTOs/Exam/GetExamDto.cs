namespace AzmoonYar.Application.DTOs.Exam;

public record GetExamDto(ExamListFilterDto Filter,
    ExamPaginationFilterDto PaginationFilter);
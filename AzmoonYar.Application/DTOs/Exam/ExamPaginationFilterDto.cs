namespace AzmoonYar.Application.DTOs.Exam;

public record ExamPaginationFilterDto(int PageNumber = 1,
    int PageSize = 10);
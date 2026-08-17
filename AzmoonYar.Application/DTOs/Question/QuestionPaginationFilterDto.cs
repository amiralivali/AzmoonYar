namespace AzmoonYar.Application.DTOs.Question;

public record QuestionPaginationFilterDto(int PageNumber = 1,
    int PageSize = 10);
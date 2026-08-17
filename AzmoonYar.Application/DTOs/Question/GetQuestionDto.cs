namespace AzmoonYar.Application.DTOs.Question;

public record GetQuestionDto(QuestionListFilterDto Filter,
    QuestionPaginationFilterDto PaginationFilter);
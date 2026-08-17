namespace AzmoonYar.API.Contracts.Question;

public record QuestionPaginationRequest(int PageNumber = 1,
    int PageSize = 10);
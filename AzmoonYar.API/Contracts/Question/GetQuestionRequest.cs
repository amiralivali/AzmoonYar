namespace AzmoonYar.API.Contracts.Question;

public record GetQuestionRequest(QuestionListFilter Filter,
    QuestionPaginationRequest PaginationRequest);
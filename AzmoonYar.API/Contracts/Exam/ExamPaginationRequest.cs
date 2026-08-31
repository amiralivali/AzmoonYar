namespace AzmoonYar.API.Contracts.Exam;

public record ExamPaginationRequest(int PageNumber = 1,
    int PageSize = 10);
namespace AzmoonYar.API.Contracts.Exam;

public record GetExamRequest(ExamListFilter Filter,ExamPaginationRequest Pagination);
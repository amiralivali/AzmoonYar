namespace AzmoonYar.API.Contracts.Dashboard;

public record SummaryResponse(int TotalBooks,
    int TotalLessons,
    int TotalQuestions,
    int TotalExams,
    List<QuestionTypeCountResponse>  QuestionTypeCounts);
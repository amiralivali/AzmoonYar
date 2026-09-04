using AzmoonYar.Application.DTOs.ActivityLog;

namespace AzmoonYar.Application.DTOs.Dashboard;

public record SummaryDto(int TotalBooks,
    int TotalLessons,
    int TotalQuestions,
    int TotalExams,
    List<QuestionTypeCountDto>  QuestionTypeCounts,
    List<ActivityLogDto>  ActivityLogs);
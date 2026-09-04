using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.DTOs.Dashboard;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Services;

public class DashboardService(IBookRepository bookRepository,
    IQuestionRepository questionRepository,
    IExamRepository  examRepository,
    IActivityLogRepository activityLogRepository)
{
    public async Task<SummaryDto> GetSummaryAsync(CancellationToken cancellationToken = default)
    {
        var totalBooks = await bookRepository.CountAsync(cancellationToken);
        var totalLessons = await bookRepository.GetLessonCount(cancellationToken);
        var totalQuestions = await questionRepository.CountAsync(cancellationToken);
        var totalExams = await examRepository.CountAsync(cancellationToken);
        var typeCounts = await questionRepository.CountByTypeAsync(cancellationToken);
        var recentLogs = await activityLogRepository.GetRecent(cancellationToken);
        return new SummaryDto(
            totalBooks,
            totalLessons,
            totalQuestions,
            totalExams,
            typeCounts.Select(ToDto).ToList(),
            recentLogs.Select(ToDto).ToList()
        );
    }

    private static ActivityLogDto ToDto(ActivityLog log)
        => new (log.Id, log.Message, log.CreatedAt);
    private static QuestionTypeCountDto ToDto(KeyValuePair<QuestionType, int> item) => new(
        item.Key,
        item.Value
    );
}
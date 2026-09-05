using AzmoonYar.API.Contracts.Dashboard;
using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.DTOs.Dashboard;

namespace AzmoonYar.API.Mappers;

public static class DashboardContractMapping
{
    public static SummaryResponse ToResponse(this SummaryDto dto)
    {
        return new SummaryResponse(dto.TotalBooks,dto.TotalLessons, dto.TotalQuestions, dto.TotalExams,
            dto.QuestionTypeCounts.Select(x=>x.ToResponse()).ToList(),
            dto.ActivityLogs.Select(x=>x.ToResponse()).ToList());
    }
}
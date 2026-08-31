using AzmoonYar.API.Contracts.Dashboard;
using AzmoonYar.Application.DTOs.Dashboard;

namespace AzmoonYar.API.Mappers;

public static class DashboardContractMapping
{
    public static SummaryResponse ToResponse(this SummaryDto dto)
    {
        return new SummaryResponse(dto.TotalBooks,dto.TotalLessons, dto.TotalQuestions, dto.TotalExams,
            dto.QuestionTypeCounts.Select(x=>x.ToResponse()).ToList());
    }
    private static QuestionTypeCountResponse ToResponse(this QuestionTypeCountDto dto)
        => new QuestionTypeCountResponse(dto.QuestionType,dto.QuestionCount);
}
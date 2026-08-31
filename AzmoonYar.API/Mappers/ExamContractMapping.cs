using AzmoonYar.API.Contracts.Exam;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.DTOs.Exam;

namespace AzmoonYar.API.Mappers;

public static class ExamContractMapping
{
    public static GetExamDto ToDto(this GetExamRequest request)
        => new (request.SearchPhrase, request.Grade, request.BookId,request.ExamDifficultyLevel, request.ExamType, request.QuestionType, request.PageNumber, request.PageSize);

    public static PagedResult<ExamResponse> ToResponse(this PagedResult<ExamDto> dto)
        => new(dto.Items.Select(x => x.ToResponse()).ToList(),
            dto.PageNumber,
            dto.PageSize,
            dto.TotalCount,
            dto.TotalPages);

    private static ExamResponse ToResponse(this ExamDto dto)
        => new(dto.Id, dto.Title, dto.Status, dto.Type, dto.CreatedAt);
}
using AzmoonYar.API.Contracts.Exam;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.DTOs.Exam;

namespace AzmoonYar.API.Mappers;

public static class ExamContractMapping
{
    public static GetExamDto ToDto(this GetExamRequest request)
        => new (new ExamListFilterDto(request.Filter.SearchPhrase,request.Filter.Grade,
                request.Filter.BookId,request.Filter.ExamDifficultyLevel,
                request.Filter.ExamType,request.Filter.QuestionType),
            new ExamPaginationFilterDto(request.Pagination.PageNumber,request.Pagination.PageSize));

    public static PagedResult<ExamResponse> ToResponse(this PagedResult<ExamDto> dto)
        => new(dto.Items.Select(x => x.ToResponse()).ToList(),
            dto.PageNumber,
            dto.PageSize,
            dto.TotalCount,
            dto.TotalPages);

    private static ExamResponse ToResponse(this ExamDto dto)
        => new(dto.Id, dto.Title, dto.Status, dto.Type, dto.CreatedAt);
}
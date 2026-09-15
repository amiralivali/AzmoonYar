using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs.Exam;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IExamService
{
    Task<PagedResult<ExamDto>> GetAllAsync(GetExamDto request, CancellationToken cancellationToken);
}
using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Exam;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;
[ApiVersion(1.0)]
public class ExamController(ExamService service) : BaseController
{
    [HttpGet(ExamUriConstants.GetAll)]
    public async Task<ApiResult<PagedResult<ExamResponse>>> GetAll(GetExamRequest filter, CancellationToken cancellationToken)
    {
        var result = await service.GetAllAsync(filter.ToDto(), cancellationToken);
        return result.ToResponse();
    }
    /*[HttpGet(ExamUriConstants.GenerateExamPdf)]
    public ApiResult<Task<byte[]>> GenerateExamPdf()
    {
       
    }*/
}
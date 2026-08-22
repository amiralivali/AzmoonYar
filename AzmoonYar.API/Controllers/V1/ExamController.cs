using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;
[ApiVersion(1.0)]
public class ExamController(ExamService service) : BaseController
{
    [HttpGet(ExamUriConstants.GenerateExamPdf)]
    public ApiResult<Task<byte[]>> GenerateExamPdf()
    {
        service.
    }
}
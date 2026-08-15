using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class OptionalItemController(QuestionService service) : BaseController
{
    [HttpPut(OptionalItemUriConstants.UpdateItem)]
    public async Task<ApiResult<OptionalItemResponse>> UpdateOptionalItem(long questionId,
        UpdateOptionalItemRequest request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateOptionalItemAsync(questionId,request.ToDto(),cancellationToken);
        return item.ToResponse();
    }
}
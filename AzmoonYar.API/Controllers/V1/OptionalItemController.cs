using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.OptionalItem;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;

[ApiVersion(1.0)]
public class OptionalItemController(OptionalItemService service) : BaseController
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
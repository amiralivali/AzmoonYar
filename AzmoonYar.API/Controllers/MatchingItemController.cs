using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.MatchingItem;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class MatchingItemController(MatchingItemService service) : BaseController
{
    [HttpPost(MatchingItemsUriConstants.AddItem)]
    public async Task<ApiResult<List<MatchingItemResponse>>> AddMatchingItem(long questionId,
        List<CreateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddMatchingItemsAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return ApiResult<List<MatchingItemResponse>>.Created(response, location: null);
    }
    
    [HttpPut(MatchingItemsUriConstants.UpdateItem)]
    public async Task<ApiResult<List<MatchingItemResponse>>> UpdateMatchingItem(long id,
        List<UpdateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateMatchingItemsAsync(id,request.ToDto(),cancellationToken);
        return item.ToResponse();
    }
    
    [HttpDelete(MatchingItemsUriConstants.DeleteItem)]
    public async Task<ApiResult> DeleteMatchingItem(long questionId,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteMatchingItemAsync(questionId,itemId,cancellationToken);
        return ApiResult.NoContent();
    }
}
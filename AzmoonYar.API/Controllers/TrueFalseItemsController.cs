using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class TrueFalseItemsController(QuestionService service) : BaseController
{
    [HttpPost(TrueFalseItemsUriConstants.AddItem)]
    public async Task<ApiResult<List<TrueFalseItemResponse>>> AddTrueFalseItem(long questionId,
        List<CreateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddTrueFalseItemAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return ApiResult<List<TrueFalseItemResponse>>.Created(response, location: null);
    }
    
    [HttpPut(TrueFalseItemsUriConstants.UpdateItem)]
    public async Task<ApiResult<List<TrueFalseItemResponse>>> UpdateTrueFalseItem(long questionId,
        List<UpdateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateTrueFalseItemAsync(questionId,request.ToDto(),cancellationToken);
        return item.ToResponse();
    }
    
    [HttpDelete(TrueFalseItemsUriConstants.DeleteItem)]
    public async Task<ApiResult> DeleteTrueFalseItem(long questionId,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteTrueFalseItemAsync(questionId,itemId,cancellationToken);
        return ApiResult.NoContent();
    }
}
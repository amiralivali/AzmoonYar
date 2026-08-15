using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class FillInBlankItemsController(QuestionService service) : BaseController
{
    [HttpPost(FillInBlankItemsUriConstants.AddItem)]
    public async Task<ApiResult<List<FillInBlankItemResponse>>> AddItem(long questionId,
        List<CreateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddFillInBlankItemAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return ApiResult<List<FillInBlankItemResponse>>.Created(response, location: null);
    }
    
    [HttpPut(FillInBlankItemsUriConstants.UpdateItem)]
    public async Task<ApiResult<List<FillInBlankItemResponse>>> UpdateItem(long questionId,
        List<UpdateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateFillInBlankItemAsync(questionId,request.ToDto(),cancellationToken);
        return item.ToResponse();
    }
    
    [HttpDelete(FillInBlankItemsUriConstants.DeleteItem)]
    public async Task<ApiResult> DeleteItem(long questionId,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteFillInBlankItemAsync(questionId,itemId,cancellationToken);
        return ApiResult.NoContent();
    }

    [HttpPost(FillInBlankItemsUriConstants.AddAnswer)]
    public async Task<ApiResult<List<FillInBlankAnswerResponse>>> AddFillInBlankAnswer(long itemId,
        List<CreateFillInBlankAnswerRequest> requests,
        CancellationToken cancellationToken)
    {
        var answers = await service.AddFillInBlankAnswersAsync(itemId,requests.ToDto(),cancellationToken);
        var response = answers.ToResponse();
        return ApiResult<List<FillInBlankAnswerResponse>>.Created(response, location: null);
    }
    
    [HttpPut(FillInBlankItemsUriConstants.UpdateAnswer)]
    public async Task<ApiResult<List<FillInBlankAnswerResponse>>> UpdateFillInBlankAnswer(long itemId,
        List<UpdateFillInBlankAnswerRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateFillInBlankAnswerAsync(itemId,request.ToDto(),cancellationToken);
        return item.ToResponse();
    }
    
    [HttpDelete(FillInBlankItemsUriConstants.DeleteAnswer)]
    public async Task<ApiResult> DeleteFillInBlankAnswer(long itemId,
        long answerId,
        CancellationToken cancellationToken)
    {
        await service.DeleteFillInBlankAnswerAsync(itemId,answerId,cancellationToken);
        return ApiResult.NoContent();
    }
}
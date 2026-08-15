using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class FillInBlankItemsController(QuestionService service) : BaseController
{
    [HttpPost(FillInBlankItemsUriConstants.AddItem)]
    public async Task<ActionResult<List<FillInBlankItemResponse>>> AddItem(long questionId,
        List<CreateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddFillInBlankItemAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new {  }, response);
    }
    
    [HttpPut(FillInBlankItemsUriConstants.UpdateItem)]
    public async Task<ActionResult<List<FillInBlankItemResponse>>> UpdateItem(long questionId,
        List<UpdateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateFillInBlankItemAsync(questionId,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete(FillInBlankItemsUriConstants.DeleteItem)]
    public async Task<ActionResult> DeleteItem(long questionId,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteFillInBlankItemAsync(questionId,itemId,cancellationToken);
        return NoContent();
    }

    [HttpPost(FillInBlankItemsUriConstants.AddAnswer)]
    public async Task<ActionResult<FillInBlankAnswerResponse>> AddFillInBlankAnswer(long itemId,
        List<CreateFillInBlankAnswerRequest> requests,
        CancellationToken cancellationToken)
    {
        var answers = await service.AddFillInBlankAnswersAsync(itemId,requests.ToDto(),cancellationToken);
        var response = answers.ToResponse();
        //return CreatedAtAction(nameof())
        return Ok(response);
    }
    
    [HttpPut(FillInBlankItemsUriConstants.UpdateAnswer)]
    public async Task<ActionResult<List<FillInBlankItemResponse>>> UpdateFillInBlankItem(long itemId,
        List<UpdateFillInBlankAnswerRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateFillInBlankAnswerAsync(itemId,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete(FillInBlankItemsUriConstants.DeleteAnswer)]
    public async Task<ActionResult> DeleteFillInBlankAnswer(long itemId,
        long answerId,
        CancellationToken cancellationToken)
    {
        await service.DeleteFillInBlankAnswerAsync(itemId,answerId,cancellationToken);
        return NoContent();
    }
}
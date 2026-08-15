using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class TrueFalseItemsController(QuestionService service) : BaseController
{
    [HttpPost(TrueFalseItemsUriConstants.AddItem)]
    public async Task<ActionResult<List<TrueFalseItemResponse>>> AddTrueFalseItem(long questionId,
        List<CreateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddTrueFalseItemAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { questionId }, response);
    }
    
    [HttpPut(TrueFalseItemsUriConstants.UpdateItem)]
    public async Task<ActionResult<List<TrueFalseItemResponse>>> UpdateTrueFalseItem(long questionId,
        List<UpdateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateTrueFalseItemAsync(questionId,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete(TrueFalseItemsUriConstants.DeleteItem)]
    public async Task<ActionResult> DeleteTrueFalseItem(long questionId,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteTrueFalseItemAsync(questionId,itemId,cancellationToken);
        return NoContent();
    }
}
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class MatchingItemsController(QuestionService service) : BaseController
{
    [HttpPost(MatchingItemsUriConstants.AddItem)]
    public async Task<ActionResult<List<MatchingItemResponse>>> AddMatchingItem(long questionId,
        List<CreateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddMatchingItemAsync(questionId,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }
    
    [HttpPut(MatchingItemsUriConstants.UpdateItem)]
    public async Task<ActionResult<List<MatchingItemResponse>>> UpdateMatchingItem(long id,
        List<UpdateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateMatchingItemAsync(id,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete(MatchingItemsUriConstants.DeleteItem)]
    public async Task<ActionResult> DeleteMatchingItem(long id,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteMatchingItemAsync(id,itemId,cancellationToken);
        return NoContent();
    }
}
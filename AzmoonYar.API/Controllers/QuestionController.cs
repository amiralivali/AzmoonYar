using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController(QuestionService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<QuestionResponse>> AddQuestion(CreateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddAsync(request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<QuestionResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var question = await service.GetByIdAsync(id, cancellationToken);
        return Ok(question.ToResponse());
    }

    [HttpGet("/QuestionType/{questionType}")]
    public async Task<ActionResult<IReadOnlyList<QuestionResponse>>> GetAllByQuestionType
        (QuestionType questionType,CancellationToken cancellationToken)
    {
        var questions = await service.GetAllByQuestionTypeAsync(questionType,cancellationToken);
        return Ok(questions.Select(x => x.ToResponse()).ToList());
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<QuestionResponse>>> GetAll
        (CancellationToken cancellationToken)
    {
        var questions = await service.GetAllAsync(cancellationToken);
        return Ok(questions.Select(x => x.ToResponse()).ToList());
    }

    [HttpPatch("{id:long}/picture")]
    public async Task<ActionResult> ChangePicture(long id, string picture, CancellationToken cancellationToken)
    {
        await service.ChangePicture(id, picture, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{Id:long}")]
    public async Task<ActionResult> DeleteQuestion(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:long}/fill-in-blank-items")]
    public async Task<ActionResult<List<FillInBlankItemResponse>>> AddFillInBlankItem(long id,
        List<CreateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddFillInBlankItemAsync(id,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }
    
    [HttpPut("{id:long}/fill-in-blank-items")]
    public async Task<ActionResult<List<FillInBlankItemResponse>>> UpdateFillInBlankItem(long id,
        List<UpdateFillInBlankItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateFillInBlankItemAsync(id,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete("{id:long}/fill-in-blank-items/{itemId:long}")]
    public async Task<ActionResult> DeleteFillInBlankItem(long id,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteFillInBlankItemAsync(id,itemId,cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:long}/true-false-items")]
    public async Task<ActionResult<List<TrueFalseItemResponse>>> AddTrueFalseItem(long id,
        List<CreateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddTrueFalseItemAsync(id,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }
    
    [HttpPut("{id:long}/true-false-items")]
    public async Task<ActionResult<List<TrueFalseItemResponse>>> UpdateTrueFalseItem(long id,
        List<UpdateTrueFalseItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateTrueFalseItemAsync(id,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete("{id:long}/true-false-items/{itemId:long}")]
    public async Task<ActionResult> DeleteTrueFalseItem(long id,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteTrueFalseItemAsync(id,itemId,cancellationToken);
        return NoContent();
    }
    
    [HttpPost("{id:long}/matching-items")]
    public async Task<ActionResult<List<MatchingItemResponse>>> AddMatchingItem(long id,
        List<CreateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.AddMatchingItemAsync(id,request.ToDto(),cancellationToken);
        var response = item.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }
    
    [HttpPut("{id:long}/matching-items")]
    public async Task<ActionResult<List<TrueFalseItemResponse>>> UpdateMatchingItem(long id,
        List<UpdateMatchingItemRequest> request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateMatchingItemAsync(id,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
    
    [HttpDelete("{id:long}/matching-items/{itemId:long}")]
    public async Task<ActionResult> DeleteMatchingItem(long id,
        long itemId,
        CancellationToken cancellationToken)
    {
        await service.DeleteMatchingItemAsync(id,itemId,cancellationToken);
        return NoContent();
    }
    
    [HttpPut("{id:long}/optional-item")]
    public async Task<ActionResult<OptionalItemResponse>> UpdateOptionalItem(long id,
        UpdateOptionalItemRequest request,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateOptionalItemAsync(id,request.ToDto(),cancellationToken);
        return Ok(item.ToResponse());
    }
}
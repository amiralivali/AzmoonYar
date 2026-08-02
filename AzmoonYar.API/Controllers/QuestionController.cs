using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController(QuestionService service) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<QuestionResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var question = await service.GetByIdAsync(id, cancellationToken);
        return Ok(question.ToResponse());
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<QuestionResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var questions = await service.GetAllAsync(cancellationToken);
        return Ok(questions.Select(x => x.ToResponse()).ToList());
    }
    
   [HttpPost("descriptive")]
   public async Task<ActionResult<QuestionResponse>> AddDescriptiveQuestion(CreateDescriptiveQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }
   
   [HttpPost("shortAnswer")]
   public async Task<ActionResult<QuestionResponse>> AddShortAnswerQuestion(CreateShortAnswerQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }
   
   [HttpPost("trueFalse")]
   public async Task<ActionResult<QuestionResponse>> AddTrueFalseQuestion(CreateTrueFalseQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }
   
   [HttpPost("fillInBlank")]
   public async Task<ActionResult<QuestionResponse>> AddFillInBlankQuestion(CreateFillInBlankQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }
   
   [HttpPost("matching")]
   public async Task<ActionResult<QuestionResponse>> AddMatchingQuestion(CreateMatchingQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }
   
   [HttpPost("optional")]
   public async Task<ActionResult<QuestionResponse>> AddOptionalQuestion(CreateOptionalQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.AddAsync(request.ToDto(),cancellationToken);
       var response = dto.ToResponse();
       return CreatedAtAction(nameof(GetById), new { id = response.QuestionId }, response);
   }

   [HttpPut("descriptive/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateDescriptiveQuestion
       (long id,UpdateDescriptiveQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpPut("shortAnswer/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateShortAnswerQuestion
       (long id ,UpdateShortAnswerQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpPut("trueFalse/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateTrueFalseQuestion
       (long id, UpdateTrueFalseQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpPut("fillInBlank/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateFillInBlankQuestion
       (long id, UpdateFillInBlankQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpPut("matching/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateMatchingQuestion
       (long id, UpdateMatchingQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpPut("optional/{Id:long}")]
   public async Task<ActionResult<QuestionResponse>> UpdateOptionalQuestion
       (long id,UpdateOptionalQuestionRequest request,CancellationToken cancellationToken)
   {
       var dto = await service.UpdateAsync(id,request.ToDto(),cancellationToken);
       return Ok(dto.ToResponse());
   }
   
   [HttpDelete("{Id:long}")]
   public async Task<IActionResult> DeleteQuestion(
       long id,
       CancellationToken cancellationToken)
   {
       await service.DeleteAsync(id, cancellationToken);
       return NoContent();
   }

   [HttpDelete("{questionId:long}/items/{itemId:long}")]
   public async Task<IActionResult> DeleteItem(
       long questionId,
       long itemId,
       CancellationToken cancellationToken)
   {
       await service.DeleteItemAsync(
           questionId,
           itemId,
           cancellationToken);

       return NoContent();
   }
}
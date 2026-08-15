using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.DTOs.Question;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;

public class QuestionController(QuestionService service) : BaseController
{
    [HttpGet(QuestionUriConstants.GetAll)]
    public async Task<ActionResult<IReadOnlyList<QuestionResponse>>> GetAll
        (CancellationToken cancellationToken)
    {
        var questions = await service.GetAllAsync(cancellationToken);
        return Ok(questions.Select(x => x.ToResponse()).ToList());
    }
    
    [HttpGet(QuestionUriConstants.GetAllByQuestionType)]
    public async Task<ActionResult<IReadOnlyList<QuestionResponse>>> GetAllByQuestionType
        (QuestionType questionType,CancellationToken cancellationToken)
    {
        var questions = await service.GetAllByQuestionTypeAsync(questionType,cancellationToken);
        return Ok(questions.Select(x => x.ToResponse()).ToList());
    }
    
    [HttpGet(QuestionUriConstants.GetById)]
    public async Task<ActionResult<QuestionResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var question = await service.GetByIdAsync(id, cancellationToken);
        return Ok(question.ToResponse());
    }
    
    [HttpGet(QuestionUriConstants.GetQuestionsCountByLessonId)]
    public async Task<ActionResult<int>> GetQuestionsCountByLessonId(long lessonId,
        CancellationToken cancellationToken)
    {
        var count = await service.GetQuestionsCountByLessonIdAsync(lessonId, cancellationToken);
        return Ok(count);
    }
    
    [HttpPost(QuestionUriConstants.Add)]
    public async Task<ActionResult<QuestionResponse>> AddQuestion(CreateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var question = await service.AddQuestionAsync(request.ToDto(),cancellationToken);
        var response = question.ToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut(QuestionUriConstants.Update)]
    public async Task<ActionResult<QuestionResponse>> UpdateQuestion(long id,UpdateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var question = await service.UpdateQuestionAsync(id,request.ToDto(), cancellationToken);
        return Ok(question.ToResponse());
    }
    
    [HttpPatch(QuestionUriConstants.ChangePicture)]
    public async Task<ActionResult> ChangePicture(long id, string picture, CancellationToken cancellationToken)
    {
        await service.ChangePicture(id, picture, cancellationToken);
        return NoContent();
    }

    [HttpDelete(QuestionUriConstants.Delete)]
    public async Task<ActionResult> DeleteQuestion(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
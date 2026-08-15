using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
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
    public async Task<ApiResult<List<QuestionResponse>>> GetAll
        (CancellationToken cancellationToken)
    {
        var questions = await service.GetAllAsync(cancellationToken);
        return questions.Select(x => x.ToResponse()).ToList();
    }
    
    [HttpGet(QuestionUriConstants.GetAllByQuestionType)]
    public async Task<ApiResult<List<QuestionResponse>>> GetAllByQuestionType
        (QuestionType questionType,CancellationToken cancellationToken)
    {
        var questions = await service.GetAllByQuestionTypeAsync(questionType,cancellationToken);
        return questions.Select(x => x.ToResponse()).ToList();
    }
    
    [HttpGet(QuestionUriConstants.GetById)]
    public async Task<ApiResult<QuestionResponse>> GetById(long id, CancellationToken cancellationToken)
    {
        var question = await service.GetByIdAsync(id, cancellationToken);
        return question.ToResponse();
    }
    
    [HttpGet(QuestionUriConstants.GetQuestionsCountByLessonId)]
    public async Task<ApiResult<int>> GetQuestionsCountByLessonId(long lessonId,
        CancellationToken cancellationToken)
    {
        var count = await service.GetQuestionsCountByLessonIdAsync(lessonId, cancellationToken);
        return count;
    }
    
    [HttpPost(QuestionUriConstants.Add)]
    public async Task<ApiResult<QuestionResponse>> AddQuestion(CreateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var question = await service.AddQuestionAsync(request.ToDto(),cancellationToken);
        var response = question.ToResponse();
        return ApiResult<QuestionResponse>.Created(response,$"/api/v1/question/{response.Id}");
    }

    [HttpPut(QuestionUriConstants.Update)]
    public async Task<ApiResult<QuestionResponse>> UpdateQuestion(long id,UpdateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var question = await service.UpdateQuestionAsync(id,request.ToDto(), cancellationToken);
        return question.ToResponse();
    }
    
    [HttpPatch(QuestionUriConstants.ChangePicture)]
    public async Task<ApiResult> ChangePicture(long id, string picture, CancellationToken cancellationToken)
    {
        await service.ChangePicture(id, picture, cancellationToken);
        return ApiResult.NoContent();
    }

    [HttpDelete(QuestionUriConstants.Delete)]
    public async Task<ApiResult> DeleteQuestion(long id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return ApiResult.NoContent();
    }
}
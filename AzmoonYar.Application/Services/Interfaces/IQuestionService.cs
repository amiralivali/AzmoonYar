using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs.Dashboard;
using AzmoonYar.Application.DTOs.Question;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> AddQuestionAsync(CreateQuestionDto dto, CancellationToken cancellationToken = default);

    Task<QuestionDto> UpdateQuestionAsync(long id, UpdateQuestionDto dto,
        CancellationToken cancellationToken = default);

    Task<QuestionDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<PagedResult<QuestionDto>> GetAllAsync(
        GetQuestionDto request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    
    Task ChangePicture(long id, string picture, CancellationToken cancellationToken = default);

    Task<int> GetQuestionsCountByLessonIdAsync(long lessonId,
        CancellationToken cancellationToken = default);

    Task<List<QuestionTypeCountDto>> GetQuestionTypeCountAsync(CancellationToken cancellationToken = default);
}
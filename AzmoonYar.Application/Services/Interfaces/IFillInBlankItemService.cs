using AzmoonYar.Application.DTOs.FillInBlankItem;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IFillInBlankItemService
{
    Task<List<FillInBlankItemDto>> AddFillInBlankItemsAsync(long id,
        List<CreateFillInBlankItemDto> items,
        CancellationToken cancellationToken = default);

    Task<List<FillInBlankItemDto>> UpdateFillInBlankItemsAsync(long id,
        List<UpdateFillInBlankItemDto> dtos,
        CancellationToken cancellationToken = default);

    Task DeleteFillInBlankItemAsync(long id, long itemId,
        CancellationToken cancellationToken = default);

    Task<List<FillInBlankAnswerDto>> AddFillInBlankAnswersAsync(long itemId,
        List<CreateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default);

    Task<List<FillInBlankAnswerDto>> UpdateFillInBlankAnswersAsync(long itemId,
        List<UpdateFillInBlankAnswerDto> fillInBlankAnswers,
        CancellationToken cancellationToken = default);

    Task DeleteFillInBlankAnswerAsync(long itemId, long answerId,
        CancellationToken cancellationToken = default);
}
using AzmoonYar.Application.DTOs.OptionalItem;
using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services.implementations;

public class OptionalItemService(IQuestionRepository repository,
    IActivityLogService logService) : IOptionalItemService
{
    public async Task<OptionalItemDto> AddOptionalItemAsync(long id, CreateOptionalItemDto dto, CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.AddOptionalItem(dto.Option1,dto.Option2,dto.Option3,dto.Option4,dto.CorrectOption);
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new OptionalItemCreatedLogData(question.Id.ToString()),question.UserId,cancellationToken);
        return ToDto(item);
    }

    public async Task<OptionalItemDto> UpdateOptionalItemAsync(long id,
        UpdateOptionalItemDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        var item = question.UpdateOptionalItem(dto.Id, dto.Option1,dto.Option2,dto.Option3,dto.Option4,dto.CorrectOption);
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new OptionalItemUpdatedLogData(question.Id.ToString()),question.UserId,cancellationToken);
        return ToDto(item);
    }
    
    public async Task DeleteOptionalItemAsync(long id,
        CancellationToken cancellationToken = default)
    {
        var question = await repository.GetByIdAsync(id, cancellationToken)
                       ?? throw new EntityNotFoundException(nameof(Question), id);
        question.RemoveOptionalItem();
        await repository.SaveChangesAsync(cancellationToken);
        await logService.AddAsync(new OptionalItemDeletedLogData(question.Id.ToString()),question.UserId,cancellationToken);
    }
    
    private static OptionalItemDto ToDto(OptionalItem item) => new(
        item.Id,
        item.Option1,
        item.Option2,
        item.Option3,
        item.Option4,
        item.CorrectOption
    );
}
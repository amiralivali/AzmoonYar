using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace AzmoonYar.Domain.Entities;

public class FillInBlankQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel,QuestionType questionType)
    : BaseQuestion(lessonId, questionText, difficultyLevel,questionType)
{
    private readonly List<FillInBlankItem> _fillInBlankItems = [];
    public IReadOnlyCollection<FillInBlankItem> FillInBlankItems => _fillInBlankItems.AsReadOnly();


    public void AddItem(string itemText)
    {
        var item = new FillInBlankItem(itemText);
        _fillInBlankItems.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        var item = _fillInBlankItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("fillInBlankItem", itemId);
        }
        _fillInBlankItems.Remove(item);
    }

    public void UpdateItem(long itemId,string itemText)
    {
        var item = _fillInBlankItems.FirstOrDefault(x=>x.Id == itemId);
        item?.UpdateItem(itemText);
    }
}
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(lessonId, questionText, difficultyLevel)
{
    private readonly List<TrueFalseItem> _trueFalseItems = [];
    public IReadOnlyCollection<TrueFalseItem> TrueFalseItems => _trueFalseItems.AsReadOnly();

    public void AddItem(string itemText)
    {
        var item = new TrueFalseItem(itemText);
        _trueFalseItems.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        var item = _trueFalseItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new NotFoundException("TrueFalse Item not found.");
        }
        _trueFalseItems.Remove(item);
    }

    public void UpdateItem(long itemId,string itemText)
    {
        var item = _trueFalseItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new NotFoundException("TrueFalse Item not found.");
        }
        item.UpdateItem(itemText);
    }
}
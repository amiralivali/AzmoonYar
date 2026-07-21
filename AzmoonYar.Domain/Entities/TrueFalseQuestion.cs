using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel,QuestionType questionType)    
    : BaseQuestion(lessonId, questionText, difficultyLevel, questionType)
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
            throw new EntityNotFoundException("trueFalseItem",itemId);
        }
        _trueFalseItems.Remove(item);
    }

    public void UpdateItem(long itemId,string itemText)
    {
        var item = _trueFalseItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("trueFalseItem",itemId);
        }
        item.UpdateItem(itemText);
    }
}
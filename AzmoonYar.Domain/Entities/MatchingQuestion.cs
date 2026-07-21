using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace AzmoonYar.Domain.Entities;

public class MatchingQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel,QuestionType questionType)
    : BaseQuestion(lessonId, questionText, difficultyLevel,questionType)
{
    private readonly List<MatchingItem> _matchingItems = [];

    public IReadOnlyCollection<MatchingItem> MatchingItems => _matchingItems.AsReadOnly();

    public void AddItem(string leftItemText,string rightItemText)
    {
        var item = new MatchingItem(leftItemText, rightItemText);
        _matchingItems.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        var item = _matchingItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("matchingItem", itemId);
        }
        _matchingItems.Remove(item);
    }

    public void UpdateItem(long itemId,string leftItemText,string rightItemText)
    {
        var item = _matchingItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("matchingItem", itemId);
        }
        item.UpdateItem(leftItemText, rightItemText);
    }
}
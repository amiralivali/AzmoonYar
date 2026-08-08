using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseItem
{
    public long Id { get; private set; }
    public long TrueFalseQuestionId { get; private set; }
    public string ItemText { get; private set; } = null!;
    public bool IsCorrect { get; set; }

    private TrueFalseItem()
    {
    }

    internal TrueFalseItem(string itemText, bool isCorrect)
    {
        ItemText = itemText;
        IsCorrect = isCorrect;
    }
    internal void UpdateItem(string itemText, bool isCorrect)
    {
        ItemText = itemText;
        IsCorrect = isCorrect;
    }
}
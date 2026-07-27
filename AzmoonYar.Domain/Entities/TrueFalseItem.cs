using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseItem
{
    public long Id { get; private set; }
    public long TrueFalseQuestionId { get; private set; }
    public string ItemText { get; private set; } = null!;

    private TrueFalseItem()
    {
    }

    internal TrueFalseItem(string itemText)
    {
        ItemText = itemText;
    }
    internal void UpdateItem(string itemText)
    {
        ItemText = itemText;
    }
}
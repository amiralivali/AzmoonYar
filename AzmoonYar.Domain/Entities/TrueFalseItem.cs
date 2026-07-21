using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseItem
{
    public long Id { get; private set; }
    public long TrueFalseQuestionId { get; private set; }
    public string ItemText { get; private set; } = null!;
    public TrueFalseQuestion TrueFalseQuestion { get; private set; } = null!;

    private TrueFalseItem()
    {
    }

    internal TrueFalseItem(string itemText)
    {
        if (string.IsNullOrWhiteSpace(itemText))
            throw new RequiredItemTextException();
        
        ItemText = itemText;
    }
    internal void UpdateItem(string itemText)
    {
        if (string.IsNullOrWhiteSpace(itemText))
            throw new RequiredItemTextException();
        
        ItemText = itemText;
    }
}
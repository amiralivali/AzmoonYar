using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class FillInBlankItem
{
    public long Id { get; private set; }
    public long FillInBlankQuestionId { get; private set; }
    public string ItemText { get; private set; } = null!;
    public FillInBlankQuestion FillInBlankQuestion { get; private set; } = null!;

    private FillInBlankItem()
    {
    }

    internal FillInBlankItem(string itemText)
    {
        if (string.IsNullOrWhiteSpace(itemText))
            throw new ValidationException("itemText cannot be empty"); 
        ItemText = itemText;
    }
    internal void UpdateItem(string itemText)
    {
        if (string.IsNullOrWhiteSpace(itemText))
            throw new ValidationException("itemText cannot be empty"); 
        
        ItemText = itemText;
    }
}
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class MatchingItem
{
    public long Id { get; private set; }
    public long MatchingQuestionId { get; private set; }
    public string LeftItemText { get; private set; } = null!;
    public string RightItemText { get; private set; } = null!;
    public MatchingQuestion MatchingQuestion { get; private set; } = null!;

    private MatchingItem()
    {
    }

    internal MatchingItem(string leftItemText, string rightItemText)
    {
        if (string.IsNullOrWhiteSpace(leftItemText))
            throw new RequiredLeftItemException();

        if (string.IsNullOrWhiteSpace(rightItemText))
            throw new RequiredRightItemException();
        LeftItemText = leftItemText;
        RightItemText = rightItemText;
    }
    internal void UpdateItem(string leftItemText, string rightItemText)
    {
        if (string.IsNullOrWhiteSpace(leftItemText))
            throw new RequiredLeftItemException();

        if (string.IsNullOrWhiteSpace(rightItemText))
            throw new RequiredRightItemException();

        LeftItemText = leftItemText.Trim();
        RightItemText = rightItemText.Trim();
    }
}
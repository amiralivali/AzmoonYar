namespace AzmoonYar.Domain.Entities;

public class MatchingItem
{
    public long Id { get;private set; }
    public string LeftItemText { get; private set; } = null!;
    public string RightItemText { get; private set; } = null!;
    public long QuestionId { get;private set; }
    public MatchingQuestion MatchingQuestion { get; private set; } = null!;

    private MatchingItem(){}
    
    public MatchingItem(long id, string leftItemText, string rightItemText, long questionId, MatchingQuestion matchingQuestion)
    {
        Id = id;
        LeftItemText = leftItemText;
        RightItemText = rightItemText;
        QuestionId = questionId;
        MatchingQuestion = matchingQuestion;
    }
}
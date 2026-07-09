namespace AzmoonYar.Domain.Entities;

public class TrueFalseItem
{
    public long Id { get; private set; }
    public string ItemText { get; private set; } = null!;
    public long QuestionId { get; private set; }
    public TrueFalseQuestion TrueFalseQuestion { get; private set; } = null!;
    private  TrueFalseItem()
    {
    }
    public TrueFalseItem(long id, string itemText, long questionId, TrueFalseQuestion trueFalseQuestion)
    {
        Id = id;
        ItemText = itemText;
        QuestionId = questionId;
        TrueFalseQuestion = trueFalseQuestion;
    }
}
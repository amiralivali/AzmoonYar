namespace AzmoonYar.Domain.Entities;

public class FillInBlankItem
{
    public long Id { get; private set; }
    public string ItemText { get; private set; } = null!;
    public long QuestionId { get; private set; }
    public FillInBlankQuestion FillInBlankQuestion { get; private set; } = null!;

private FillInBlankItem(){}
    public FillInBlankItem(long id, string itemText, long questionId, FillInBlankQuestion fillInBlankQuestion)
    {
        Id = id;
        ItemText = itemText;
        QuestionId = questionId;
        FillInBlankQuestion = fillInBlankQuestion;
    }
}
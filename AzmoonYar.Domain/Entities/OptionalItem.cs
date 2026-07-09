namespace AzmoonYar.Domain.Entities;

public class OptionalItem
{
    public long Id { get; private set; }
    public string Option1 { get; private set; }= null!;
    public string Option2 { get; private set; } = null!;
    public string Option3 { get; private set; }= null!;
    public string Option4 { get; private set; }= null!;
    public long QuestionId { get; private set; }
    public OptionalQuestion OptionalQuestion { get; private set; } = null!;
private OptionalItem(){}
    public OptionalItem(long id, string option1, string option2, string option3, string option4, long questionId, OptionalQuestion optionalQuestion)
    {
        Id = id;
        Option1 = option1;
        Option2 = option2;
        Option3 = option3;
        Option4 = option4;
        QuestionId = questionId;
        OptionalQuestion = optionalQuestion;
    }
}
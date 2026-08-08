using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class OptionalItem
{
    public long Id { get; private set; }
    public string Option1 { get; private set; } = null!;
    public string Option2 { get; private set; } = null!;
    public string Option3 { get; private set; } = null!;
    public string Option4 { get; private set; } = null!;
    public OptionNumber CorrectOption { get; set; } 
    public long QuestionId { get; private set; }

    private OptionalItem()
    {
    }

    internal OptionalItem(
        string option1,
        string option2,
        string option3,
        string option4,
        OptionNumber correctOption)
    {
        Option1 = option1.Trim();
        Option2 = option2.Trim();
        Option3 = option3.Trim();
        Option4 = option4.Trim();
        CorrectOption =  correctOption;
    }

    internal void Update(
        string option1,
        string option2,
        string option3,
        string option4,
        OptionNumber correctOption)
    {
        Option1 = option1.Trim();
        Option2 = option2.Trim();
        Option3 = option3.Trim();
        Option4 = option4.Trim();
        CorrectOption = correctOption;
    }
}
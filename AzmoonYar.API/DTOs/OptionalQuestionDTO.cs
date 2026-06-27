namespace AzmoonYar.API.DTOs;

public class OptionalQuestionDto(
    int id,
    string questionText,
    string option1,
    string option2,
    string option3,
    string option4)
{
    public int Id { get; set; } = id;
    public string QuestionText { get; set; } = questionText;
    public string Option1 { get; set; } = option1;
    public string Option2 { get; set; } = option2;
    public string Option3 { get; set; } = option3;
    public string Option4 { get; set; } = option4;
}
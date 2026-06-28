namespace AzmoonYar.API.Models;

public class OptionalQuestion(int id, int lessonId, string questionText, string picture, int difficultyLevelId, string option1, string option2, string option3, string option4)
{
    public int Id { get; set; } = id;
    public int LessonId { get; set; } = lessonId;
    public string QuestionText { get; set; } = questionText;
    public string Picture { get; set; } = picture;
    public int DifficultyLevelId { get; set; } = difficultyLevelId;
    public string Option1 { get; set; } = option1;
    public string Option2 { get; set; } = osption2;
    public string Option3 { get; set; } = option3;
    public string Option4 { get; set; } = option4;
}   
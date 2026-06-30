namespace AzmoonYar.API.Models;

public class OptionalQuestion
{
    public OptionalQuestion(int id, int lessonId, string questionText, string picture, int difficultyLevelId, string option1, string option2, string option3, string option4)
    {
        Id = id;
        LessonId = lessonId;
        QuestionText = questionText;
        Picture = picture;
        DifficultyLevelId = difficultyLevelId;
        Option1 = option1;
        Option2 = option2;
        Option3 = option3;
        Option4 = option4;
    }

    public int Id { get; set; }
    public int LessonId { get; set; }
    public string QuestionText { get; set; }
    public string Picture { get; set; }
    public int DifficultyLevelId { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; } 
    public string Option4 { get; set; } 
}
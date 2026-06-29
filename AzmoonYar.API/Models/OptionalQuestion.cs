namespace AzmoonYar.API.Models;

public class OptionalQuestion
{
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
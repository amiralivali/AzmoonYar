namespace AzmoonYar.API.Models;

public class OptionalQuestion(int id, int lessonId, string questionText, string picture, int difficultyLevelId)
{
    public int Id { get; set; } = id;
    public int LessonId { get; set; } = lessonId;
    public string QuestionText { get; set; } = questionText;
    public string Picture { get; set; } = picture;
    public int DifficultyLevelId { get; set; } = difficultyLevelId;
}   
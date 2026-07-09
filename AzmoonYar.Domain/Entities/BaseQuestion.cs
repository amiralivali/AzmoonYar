using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public abstract class BaseQuestion
{
    public long Id { get; private set; }
    public long LessonId { get; private set; }
    public string QuestionText { get; private set; } = null!;
    public string? Picture { get; private set; }
    public DifficultyLevel DifficultyLevel { get; private set; }
    public Lesson Lesson { get; set; } = null!;
    
    private BaseQuestion(){}

    protected BaseQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    {
        Id = id;
        LessonId = lessonId;
        QuestionText = questionText;
        DifficultyLevel = difficultyLevel;
    }
}
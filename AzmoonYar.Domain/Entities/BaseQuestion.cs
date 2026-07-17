using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public abstract class BaseQuestion
{
    public long Id { get; private set; }
    public long LessonId { get; private set; }
    public string QuestionText { get; private set; } = null!;
    public string? Picture { get; private set; }
    public DifficultyLevel DifficultyLevel { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    
    public Lesson? Lesson { get; private set; }

    private BaseQuestion()
    {
    }

    protected BaseQuestion(
        long lessonId,
        string questionText,
        DifficultyLevel difficultyLevel)
    {
        if (string.IsNullOrWhiteSpace(questionText))
            throw new ValidationException("Question text cannot be empty.");
        
        LessonId = lessonId;
        QuestionText = questionText.Trim();
        DifficultyLevel = difficultyLevel;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateQuestion(
        long lessonId,
        string questionText,
        DifficultyLevel difficultyLevel)
    {
        if (string.IsNullOrWhiteSpace(questionText))
            throw new ValidationException("Question text cannot be empty.");

        LessonId = lessonId;
        QuestionText = questionText.Trim();
        DifficultyLevel = difficultyLevel;
    }

    public void ChangePicture(string? picture)
    {
        Picture = picture;
    }
}
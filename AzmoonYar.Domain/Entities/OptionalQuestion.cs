using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class OptionalQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(id, lessonId, questionText, difficultyLevel)
{
    public OptionalItem OptionalItem { get;private set; } = null!;
}
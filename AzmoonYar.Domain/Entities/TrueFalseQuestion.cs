using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class TrueFalseQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(id, lessonId, questionText, difficultyLevel)
{
    public ICollection<TrueFalseItem> TrueFalseItems { get;private set; } = null!;
}
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class MatchingQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(id, lessonId, questionText, difficultyLevel)

{
    public ICollection<MatchingItem> MatchingItems { get; private set; } = null!;
}
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class DescriptiveQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(id, lessonId, questionText, difficultyLevel);   
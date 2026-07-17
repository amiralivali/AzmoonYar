using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class DescriptiveQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(lessonId, questionText, difficultyLevel);   
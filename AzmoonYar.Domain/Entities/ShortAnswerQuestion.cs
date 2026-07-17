using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class ShortAnswerQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(lessonId, questionText, difficultyLevel);
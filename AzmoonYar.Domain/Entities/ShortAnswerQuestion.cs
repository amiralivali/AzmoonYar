using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class ShortAnswerQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel,QuestionType questionType)
    : BaseQuestion(lessonId, questionText, difficultyLevel,questionType);
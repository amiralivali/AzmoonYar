using System.Runtime.InteropServices.ComTypes;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class FillInBlankQuestion(long id, long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(id, lessonId, questionText, difficultyLevel)

{
    public ICollection<FillInBlankItem> FillInBlankItems { get; private set; } = null!;
}
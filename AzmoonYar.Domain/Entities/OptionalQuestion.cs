using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class OptionalQuestion(long lessonId, string questionText, DifficultyLevel difficultyLevel)
    : BaseQuestion(lessonId, questionText, difficultyLevel)
{
    public OptionalItem OptionalItem { get; private set; } = null!;

    public void AddItem(string option1, string option2, string option3, string option4)
    {
        OptionalItem = new OptionalItem(option1, option2, option3, option4);
    }

    public void UpdateItem(string option1, string option2, string option3, string option4)
    {
        OptionalItem.Update(option1, option2, option3, option4);
    }
    public void RemoveOptions()
    {
        OptionalItem = null!;
    }
}
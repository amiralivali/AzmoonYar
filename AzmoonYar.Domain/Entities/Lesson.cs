using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class Lesson
{
    public long Id { get; private set; }
    public string LessonName { get; private set; } = null!;
    public string? Title { get; private set; }
    public long BookId { get; private set; }
    public int LessonCount { get; private set; }
    public Book Book { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; private set; }


    private Lesson()
    {
    }

    internal Lesson(int lessonCount)
    {
        LessonName = $"Lesson {lessonCount}:";
        LessonCount = lessonCount;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    internal void ChangeTitle(string? title)
    {
        Title = string.IsNullOrWhiteSpace(title)
            ? null
            : title.Trim();

        LessonName = Title is null
            ? $"درس {LessonCount}"
            : $"درس {LessonCount}: {Title}";
    }
}
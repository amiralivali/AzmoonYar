using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class Book
{
    private readonly List<Lesson> _lessons = [];

    public long Id { get; private set; }
    public string BookName { get; private set; } = null!;
    public Grade Grade { get; private set; }
    public string? GradeInfo { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();

    private Book()
    {
    }

    public Book(string bookName, Grade grade)
    {
        var nextLessonCount = _lessons.Any()
            ? _lessons.Max(x => x.LessonCount) + 1
            : 1;
        var lesson = new Lesson(nextLessonCount);
        _lessons.Add(lesson);
    }

    public void UpdateBook(
        string bookName,
        Grade grade,
        string? gradeInfo)
    {
        if (string.IsNullOrWhiteSpace(bookName))
            throw new ValidationException("Book name is required.");

        BookName = bookName.Trim();
        Grade = grade;
        GradeInfo = gradeInfo;
    }

    public void ChangeGradeInfo(string? gradeInfo)
    {
        GradeInfo = gradeInfo;
    }

    public void AddLesson()
    {
        var lesson = new Lesson(_lessons.Count+1);

        _lessons.Add(lesson);
    }

    public void RemoveLesson(long lessonId)
    {
        var lesson = _lessons.FirstOrDefault(x=>x.Id == lessonId);
        if (lesson is null)
        {
            throw new NotFoundException("Lesson not found.");
        }
        _lessons.Remove(lesson);
    }
    public void ChangeTitle(long lessonId,string title)
    {
        var lesson = _lessons.FirstOrDefault(x=>x.Id == lessonId);
        if (lesson is null)
        {
            throw new NotFoundException("Lesson not found.");
        }
        lesson.ChangeTitle(title);
    }
}
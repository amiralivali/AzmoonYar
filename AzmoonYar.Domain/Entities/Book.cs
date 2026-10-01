using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class Book
{
    private readonly List<Lesson> _lessons = [];

    public long Id { get; private set; }
    public long UserId { get; private set; }
    public string BookName { get; private set; } = null!;
    public Grade Grade { get; private set; }
    public BookSource BookSource { get; private set; }
    public string? Picture { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();

    private Book()
    {
    }

    public Book(string bookName,
        long userId, Grade grade,
        BookSource bookSource)
    {
        BookName = bookName.Trim();
        Grade = grade;
        BookSource = bookSource;
        UserId = userId;
    }

    public void UpdateBook(
        string bookName,
        Grade grade,
        BookSource bookSource)
    {
        BookName = bookName.Trim();
        Grade = grade;
        BookSource = bookSource;
    }

    public void AddLesson(int lessonNumber,string? title)
    {
        if (_lessons.Any(x => x.LessonCount==lessonNumber))
        {
            throw new DuplicateLessonNumber();
        }
        
        var lesson = new Lesson(lessonNumber);
        lesson.ChangeTitle(title);
        _lessons.Add(lesson);
    }

    public void RemoveLesson(long lessonId)
    {
        var lesson = _lessons.FirstOrDefault(x=>x.Id == lessonId);
        if (lesson is null)
        {
            throw new EntityNotFoundException("lesson", lessonId);
        }
        _lessons.Remove(lesson);
    }
    public void ChangeLessonTitle(int lessonNumber,string title)
    {
        var lesson = _lessons.FirstOrDefault(x=>x.LessonCount == lessonNumber);
        if (lesson is null)
        {
            throw new EntityNotFoundException("lesson", lessonNumber);
        }
        lesson.ChangeTitle(title);
    }
    
    public void ChangePicture(string picture)
    {
        Picture = picture;
    }
}
namespace AzmoonYar.Domain.Entities;

public class Lesson
{
    public long Id { get; private set; }
    public string? LessonName { get; private set; }
    public long BookId { get; private set; }
    public int LessonCount { get; private set; }
    public Book Book { get; private set; } = null!;
    public ICollection<DescriptiveQuestion> DescriptiveQuestions { get; private set; } = null!;
    public ICollection<ShortAnswerQuestion> ShortAnswerQuestions { get; private set; } = null!;
    public ICollection<OptionalQuestion> OptionalQuestions { get; private set; } = null!;
    public ICollection<TrueFalseQuestion> TrueFalseQuestions { get; private set; } = null!;
    public ICollection<MatchingQuestion> MatchingQuestions { get; private set; } = null!;
    public ICollection<FillInBlankQuestion> FillInBlankQuestions { get; private set; } = null!;
    private Lesson(){}
    public Lesson(long id, long bookId, int lessonCount)
    {
        Id = id;
        LessonName = "lesson " + lessonCount;
        BookId = bookId;
        LessonCount = lessonCount;
    }
}
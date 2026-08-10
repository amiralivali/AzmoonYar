using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class Exam
{
    public long Id { get; private set; }
    public long BookId { get; private set; }

    // private readonly List<Lesson> _lessons = [];
    // public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();
    
    private readonly List<ExamQuestionType> _examQuestionTypes = [];
    public IReadOnlyCollection<ExamQuestionType> ExamQuestionTypes =>
        _examQuestionTypes.AsReadOnly();
    
    public int QuestionsCount =>
        _examQuestionTypes.Sum(x => x.Count);
    
    public ExamType ExamType { get; private set; }
    public DifficultyLevel DifficultyLevel { get; private set; }
    public ExportType ExportType { get; private set; }
    public string? HeaderPicture { get; private set; }
    public string? LogoPicture { get; private set; }
    public string? HeaderText { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Book Book { get; private set; } = null!;
    private Exam()
    {
    }

    public Exam(
        long bookId,
        //IEnumerable<long> lessonIds,
        ExamType examType,
        DifficultyLevel difficultyLevel,
        ExportType exportType)
    {
        BookId = bookId;
        ExamType = examType;
        DifficultyLevel = difficultyLevel;
        ExportType = exportType;
        CreatedAt =  DateTimeOffset.Now;
    }

    public void AddQuestionType(QuestionType questionType, int count)
    {
        if (count <= 0)
            throw new ArgumentException(
                "Question count must be greater than zero.");

        if (_examQuestionTypes.Any(x => x.QuestionType == questionType))
            throw new InvalidOperationException(
                "This question type already exists in the exam.");

        _examQuestionTypes.Add(
            new ExamQuestionType(questionType, count));
    }
}
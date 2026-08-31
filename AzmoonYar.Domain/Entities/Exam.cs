using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Domain.Entities;

public class Exam
{
    public long Id { get; private set; }
    public long BookId { get; private set; }
    
    private readonly List<ExamQuestionType> _examQuestionTypes = [];
    public IReadOnlyCollection<ExamQuestionType> ExamQuestionTypes =>
        _examQuestionTypes.AsReadOnly();

    private readonly List<ExamQuestion> _examQuestions = [];
    public IReadOnlyCollection<ExamQuestion> ExamQuestions =>
        _examQuestions.AsReadOnly();

    public int QuestionsCount =>
        _examQuestionTypes.Sum(x => x.Count);

    public ExamType ExamType { get; private set; }
    public ExamDifficultyLevel DifficultyLevel { get; private set; }
    public ExamHeader ExamHeader { get; private set; } = null!;
    public ExamStatus ExamStatus { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    
    public Book Book { get; private set; } = null!;
    public ICollection<Lesson> Lessons { get; private set; } = null!;

    private Exam()
    {}

    public Exam(long bookId, ICollection<Lesson> lessons, ExamType examType, ExamDifficultyLevel difficultyLevel, ExamHeader header,ExamStatus examStatus)
    {
        BookId = bookId;
        Lessons = lessons;
        ExamType = examType;
        DifficultyLevel = difficultyLevel;
        CreatedAt = DateTimeOffset.UtcNow;
        ExamHeader = header;
        ExamStatus = examStatus;
    }

    public void AddQuestionType(QuestionType questionType, int count)
    {
        if (count <= 0)
            throw new InvalidQuestionCount();

        if (_examQuestionTypes.Any(x => x.QuestionType == questionType))
            throw new QuestionTypeAlreadyExistException();

        _examQuestionTypes.Add(
            new ExamQuestionType(questionType, count));
    }

    public void AddQuestion(long questionId, decimal score, bool shuffleOptions = true)
    {
        if (_examQuestions.Any(x => x.QuestionId == questionId))
            throw new QuestionAlreadyExistException();

        var order = _examQuestions.Count + 1;
        _examQuestions.Add(new ExamQuestion(questionId, order, score, shuffleOptions));
    }

    public void RemoveQuestion(long questionId)
    {
        var item = _examQuestions.FirstOrDefault(x => x.QuestionId == questionId);
        if (item is null)
            throw new QuestionNotFoundInExamException();

        _examQuestions.Remove(item);
        ReorderQuestions();
    }

    public void ReorderQuestion(long questionId, int newOrder)
    {
        var item = _examQuestions.FirstOrDefault(x => x.QuestionId == questionId);
        if (item is null)
            throw new QuestionNotFoundInExamException();

        item.ChangeOrder(newOrder);
    }

    private void ReorderQuestions()
    {
        var ordered = _examQuestions.OrderBy(x => x.Order).ToList();
        for (var i = 0; i < ordered.Count; i++)
            ordered[i].ChangeOrder(i + 1);
    }
    
    private void ChangeStatus(ExamStatus newStatus)
    {
        ExamStatus = newStatus;
    }
}
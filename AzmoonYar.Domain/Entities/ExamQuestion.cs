using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class ExamQuestion
{
    public long Id { get; private set; }
    public long ExamId { get; private set; }
    public long QuestionId { get; private set; }
    public Question Question { get; private set; } = null!;
    public int Order { get; private set; }
    public decimal Score { get; private set; }
    public bool ShuffleOptions { get; private set; }

    private ExamQuestion()
    {}

    public ExamQuestion(long questionId, int order, decimal score, bool shuffleOptions = true)
    {
        if (score <= 0)
            throw new InvalidScoreException();

        QuestionId = questionId;
        Order = order;
        Score = score;
        ShuffleOptions = shuffleOptions;
    }

    public void ChangeOrder(int newOrder)
    {
        Order = newOrder;
    }

    public void ChangeScore(decimal score)
    {
        if (score <= 0)
            throw new InvalidScoreException();

        Score = score;
    }
}
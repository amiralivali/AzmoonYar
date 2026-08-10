using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class ExamQuestionType
{
    public long Id { get; private set; }
    public long ExamId { get; private set; }
    public QuestionType QuestionType { get; private set; }
    public int Count { get; private set; }

    private ExamQuestionType()
    {
        
    }
    
    public ExamQuestionType(QuestionType questionType,int count)
    {
        QuestionType = questionType;
        Count = count;
    }
}
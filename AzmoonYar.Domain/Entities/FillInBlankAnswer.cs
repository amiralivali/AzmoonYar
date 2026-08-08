using System.Runtime;

namespace AzmoonYar.Domain.Entities;

public class FillInBlankAnswer
{
    public long Id { get; private set; }
    public long FillInBlankItemId { get; private set; }
    public string Answer { get; private set; } = null!;

    private FillInBlankAnswer()
    {}
    
    public FillInBlankAnswer(string answer)
    {
        Answer = answer.Trim();
    }

    public void Update(string answer)
    {
        Answer = answer.Trim();
    }
}
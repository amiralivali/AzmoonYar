using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class FillInBlankItem
{
    private readonly List<FillInBlankAnswer> _answers = [];
    
    public long Id { get; private set; }
    public long FillInBlankQuestionId { get; private set; }
    public string ItemText { get; private set; } = null!;
    public IReadOnlyCollection<FillInBlankAnswer> Answers => _answers.AsReadOnly();

    private FillInBlankItem()
    {
    }

    internal FillInBlankItem(string itemText)
    {
        ItemText = itemText;
    }
    public void UpdateItem(string itemText)
    {
        ItemText = itemText;
    }

    public FillInBlankAnswer AddAnswer(string answer)
    {
        var fillInBlankAnswer = new FillInBlankAnswer(answer);
        _answers.Add(fillInBlankAnswer);
        return fillInBlankAnswer;
    }
    public FillInBlankAnswer UpdateAnswer(long id, string answer)
    {
        var fillInBlankAnswer = _answers.FirstOrDefault(x => x.Id == id) 
                                ?? throw new EntityNotFoundException(nameof(FillInBlankAnswer), id);
        fillInBlankAnswer.Update(answer);
        return fillInBlankAnswer;
    }

    public void DeleteAnswer(long id)
    {
        var fillInBlankAnswer = _answers.FirstOrDefault(x => x.Id == id)
            ?? throw new EntityNotFoundException(nameof(FillInBlankAnswer), id);
        _answers.Remove(fillInBlankAnswer);
    }
}
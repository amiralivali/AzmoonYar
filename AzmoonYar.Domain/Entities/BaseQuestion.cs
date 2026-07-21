using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class BaseQuestion
{
    public long Id { get; private set; }
    public long LessonId { get; private set; }
    public string QuestionText { get; private set; } = null!;
    public string? Picture { get; private set; }
    public DifficultyLevel DifficultyLevel { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public QuestionType QuestionType { get; private set; }
    public Lesson? Lesson { get; private set; }
    
    private readonly List<FillInBlankItem> _fillInBlankItems = [];
    public IReadOnlyCollection<FillInBlankItem> FillInBlankItems => _fillInBlankItems.AsReadOnly();
    
    
    private readonly List<MatchingItem> _matchingItems = [];
    public IReadOnlyCollection<MatchingItem> MatchingItems => _matchingItems.AsReadOnly();
    
    
    public OptionalItem OptionalItem { get; private set; } = null!;

    
    private readonly List<TrueFalseItem> _trueFalseItems = [];
    public IReadOnlyCollection<TrueFalseItem> TrueFalseItems => _trueFalseItems.AsReadOnly();
    private BaseQuestion()
    {
    }

    protected BaseQuestion(
        long lessonId,
        string questionText,
        DifficultyLevel difficultyLevel,
        QuestionType  questionType)
    {
        if (string.IsNullOrWhiteSpace(questionText))
            throw new RequiredQuestionTextException();
        
        LessonId = lessonId;
        QuestionText = questionText.Trim();
        DifficultyLevel = difficultyLevel;
        QuestionType = questionType;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    public void ChangePicture(string? picture)
    {
        Picture = picture;
    }
    
    public void AddFillInBlankItem(string itemText)
    {
        var item = new FillInBlankItem(itemText);
        _fillInBlankItems.Add(item);
    }
    public void RemoveFillInBlankItem(long itemId)
    {
        var item = _fillInBlankItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("fillInBlankItem", itemId);
        }
        _fillInBlankItems.Remove(item);
    }
    
    public void AddMatchingItem(string leftItemText,string rightItemText)
    {
        var item = new MatchingItem(leftItemText, rightItemText);
        _matchingItems.Add(item);
    }
    public void RemoveMatchingItem(long itemId)
    {
        var item = _matchingItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("matchingItem", itemId);
        }
        _matchingItems.Remove(item);
    }
    
    public void AddOptionalItem(string option1, string option2, string option3, string option4)
    {
        OptionalItem = new OptionalItem(option1, option2, option3, option4);
    }
    public void RemoveOptions()
    {
        OptionalItem = null!;
    }
    
    public void AddTrueFalseItem(string itemText)
    {
        var item = new TrueFalseItem(itemText);
        _trueFalseItems.Add(item);
    }
    public void RemoveTrueFalseItem(long itemId)
    {
        var item = _trueFalseItems.FirstOrDefault(x=>x.Id == itemId);
        if (item is null)
        {
            throw new EntityNotFoundException("trueFalseItem",itemId);
        }
        _trueFalseItems.Remove(item);
    }
}
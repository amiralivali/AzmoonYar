using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Domain.Entities;

public class Question
{
    private readonly List<FillInBlankItem> _fillInBlankItems = [];
    private readonly List<MatchingItem> _matchingItems = [];
    private readonly List<TrueFalseItem> _trueFalseItems = [];

    public long Id { get; private set; }

    public long LessonId { get; private set; }

    public string QuestionText { get; private set; } = null!;

    public string? Picture { get; private set; }

    public DifficultyLevel DifficultyLevel { get; private set; }

    public QuestionType QuestionType { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public Lesson? Lesson { get; private set; }

    public IReadOnlyCollection<FillInBlankItem> FillInBlankItems => _fillInBlankItems.AsReadOnly();

    public IReadOnlyCollection<MatchingItem> MatchingItems => _matchingItems.AsReadOnly();

    public IReadOnlyCollection<TrueFalseItem> TrueFalseItems => _trueFalseItems.AsReadOnly();

    public OptionalItem? OptionalItem { get; private set; }

    private Question()
    {
    }

    public Question(
        long lessonId,
        string questionText,
        DifficultyLevel difficultyLevel,
        QuestionType questionType)
    {
        LessonId = lessonId;
        QuestionText = questionText.Trim();
        DifficultyLevel = difficultyLevel;
        QuestionType = questionType;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateQuestion(long lessonId,
        string questionText,
        DifficultyLevel difficultyLevel,
        QuestionType questionType)
    {
        LessonId = lessonId;
        QuestionText = questionText.Trim();
        DifficultyLevel = difficultyLevel;
        QuestionType = questionType;
    }
    
    public void ChangePicture(string? picture)
    {
        Picture = string.IsNullOrWhiteSpace(picture)
            ? null
            : picture.Trim();
    }

    #region FillInBlank

    public FillInBlankItem AddFillInBlankItem(string itemText)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new FillInBlankItemOperationNotAllowedException();

        var item = new FillInBlankItem(itemText);
        _fillInBlankItems.Add(item);
        return item;
    }

    public void RemoveFillInBlankItem(long itemId)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new FillInBlankItemOperationNotAllowedException();

        var item = _fillInBlankItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);

        _fillInBlankItems.Remove(item);
    }

    public FillInBlankItem UpdateFillInBlankItem(long itemId, string itemText)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new FillInBlankItemOperationNotAllowedException();

        var item = _fillInBlankItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);
        
        item.UpdateItem(itemText);
        return item;
    }
    
    #endregion

    #region Matching

    public MatchingItem AddMatchingItem(string leftItemText, string rightItemText)
    {
        if (QuestionType != QuestionType.Matching)
            throw new MatchingItemOperationNotAllowedException();

        var item = new MatchingItem(leftItemText, rightItemText);
        _matchingItems.Add(item);
        return item;
    }

    public void RemoveMatchingItem(long itemId)
    {
        if (QuestionType != QuestionType.Matching)
            throw new MatchingItemOperationNotAllowedException();

        var item = _matchingItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(MatchingItem), itemId);

        _matchingItems.Remove(item);
    }

    public MatchingItem UpdateMatchingItem(long itemId, string leftItemText, string rightItemText)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new MatchingItemOperationNotAllowedException();

        var item = _matchingItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(MatchingItem), itemId);
        
        item.UpdateItem(leftItemText, rightItemText);
        return item;
    }
    
    #endregion

    #region Optional

    public OptionalItem AddOptionalItem(
        string option1,
        string option2,
        string option3,
        string option4)
    {
        if (QuestionType != QuestionType.Optional)
            throw new OptionalItemOperationNotAllowedException();

        if (OptionalItem is not null)
            throw new OptionalItemAlreadyExistsException();

        OptionalItem = new OptionalItem(
            option1,
            option2,
            option3,
            option4);
        return OptionalItem;
    }

    public OptionalItem UpdateOptionalItem(long id,string option1, string option2, string option3, string option4)
    {
        if (QuestionType != QuestionType.Optional)
            throw new OptionalItemOperationNotAllowedException();
        
        if (OptionalItem is null)
            throw new EntityNotFoundException(nameof(OptionalItem), id);
        OptionalItem.Update(option1, option2, option3, option4);
        return OptionalItem;
    }

    #endregion

    #region TrueFalse

    public TrueFalseItem AddTrueFalseItem(string itemText)
    {
        if (QuestionType != QuestionType.TrueFalse)
            throw new TrueFalseItemOperationNotAllowedException();

        var item =  new TrueFalseItem(itemText);
        _trueFalseItems.Add(item);
        return item;
    }

    public void RemoveTrueFalseItem(long itemId)
    {
        if (QuestionType != QuestionType.TrueFalse)
            throw new TrueFalseItemOperationNotAllowedException();

        var item = _trueFalseItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(TrueFalseItem), itemId);

        _trueFalseItems.Remove(item);
    }

    public TrueFalseItem UpdateTrueFalseItem(long itemId, string itemText)
    {
        if (QuestionType != QuestionType.TrueFalse)
            throw new TrueFalseItemOperationNotAllowedException();

        var item = _trueFalseItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(TrueFalseItem), itemId);

        item.UpdateItem(itemText);
        return item;
    }
    
    #endregion
}
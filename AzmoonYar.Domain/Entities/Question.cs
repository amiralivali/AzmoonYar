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

    public void ChangePicture(string? picture)
    {
        Picture = string.IsNullOrWhiteSpace(picture)
            ? null
            : picture.Trim();
    }

    #region FillInBlank

    public void AddFillInBlankItem(string itemText)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new FillInBlankItemOperationNotAllowedException();

        _fillInBlankItems.Add(new FillInBlankItem(itemText));
    }

    public void RemoveFillInBlankItem(long itemId)
    {
        if (QuestionType != QuestionType.FillInBlank)
            throw new FillInBlankItemOperationNotAllowedException();

        var item = _fillInBlankItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(FillInBlankItem), itemId);

        _fillInBlankItems.Remove(item);
    }

    #endregion

    #region Matching

    public void AddMatchingItem(string leftItemText, string rightItemText)
    {
        if (QuestionType != QuestionType.Matching)
            throw new MatchingItemOperationNotAllowedException();

        _matchingItems.Add(new MatchingItem(leftItemText, rightItemText));
    }

    public void RemoveMatchingItem(long itemId)
    {
        if (QuestionType != QuestionType.Matching)
            throw new MatchingItemOperationNotAllowedException();

        var item = _matchingItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(MatchingItem), itemId);

        _matchingItems.Remove(item);
    }

    #endregion

    #region Optional

    public void AddOptionalItem(
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
    }

    public void RemoveOptionalItem()
    {
        if (QuestionType != QuestionType.Optional)
            throw new OptionalItemOperationNotAllowedException();

        if (OptionalItem is null)
            throw new EntityNotFoundException(nameof(OptionalItem), 0);

        OptionalItem = null;
    }

    #endregion

    #region TrueFalse

    public void AddTrueFalseItem(string itemText)
    {
        if (QuestionType != QuestionType.TrueFalse)
            throw new TrueFalseItemOperationNotAllowedException();

        _trueFalseItems.Add(new TrueFalseItem(itemText));
    }

    public void RemoveTrueFalseItem(long itemId)
    {
        if (QuestionType != QuestionType.TrueFalse)
            throw new TrueFalseItemOperationNotAllowedException();

        var item = _trueFalseItems.FirstOrDefault(x => x.Id == itemId)
                   ?? throw new EntityNotFoundException(nameof(TrueFalseItem), itemId);

        _trueFalseItems.Remove(item);
    }

    #endregion
}
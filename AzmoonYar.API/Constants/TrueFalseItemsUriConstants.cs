namespace AzmoonYar.API.Constants;

public static class TrueFalseItemsUriConstants
{
    private const string QuestionController = "question";
    private const string ItemsSegment = "true-false-items";

    public const string AddItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}";
    public const string UpdateItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}";
    public const string DeleteItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}/{{itemId:long}}";
}
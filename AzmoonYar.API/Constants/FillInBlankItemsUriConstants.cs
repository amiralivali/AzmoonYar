namespace AzmoonYar.API.Constants;

public static class FillInBlankItemsUriConstants
{
    private const string QuestionController = "question";
    private const string ItemsSegment = "fill-in-blank-items";
    private const string AnswersSegment = "fill-in-blank-answers";

    public const string AddItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}";
    public const string UpdateItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}";
    public const string DeleteItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}/{{itemId:long}}";

    public const string AddAnswer = $"{ItemsSegment}/{{itemId:long}}/{AnswersSegment}";
    public const string UpdateAnswer = $"{ItemsSegment}/{{itemId:long}}/{AnswersSegment}";
    public const string DeleteAnswer = $"{ItemsSegment}/{{itemId:long}}/{AnswersSegment}/{{answerId:long}}";
}
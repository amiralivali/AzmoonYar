namespace AzmoonYar.API.Constants;

public static class OptionalItemUriConstants
{
    private const string QuestionController = "question";
    private const string ItemsSegment = "optional-item";

    public const string UpdateItem = $"{QuestionController}/{{questionId:long}}/{ItemsSegment}";
}
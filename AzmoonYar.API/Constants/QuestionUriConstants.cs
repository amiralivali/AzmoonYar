namespace AzmoonYar.API.Constants;

public static class QuestionUriConstants
{
    private const string Controller = "question";

    public const string GetAll = $"{Controller}";
    public const string GetById = $"{Controller}/{{id:long}}";
    public const string Add = $"{Controller}";
    public const string Update = $"{Controller}/{{id:long}}";
    public const string GetAllByQuestionType = $"{Controller}/by-question-type/{{questionType}}";
    public const string ChangePicture = $"{Controller}/{{id:long}}/picture";
    public const string Delete = $"{Controller}/{{id:long}}";
    public const string GetQuestionsCountByLessonId = $"{Controller}/count-by-lesson/{{lessonId:long}}";
}
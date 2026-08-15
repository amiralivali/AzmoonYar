namespace AzmoonYar.API.Constants;

public static class BookUriConstants
{
    private const string Controller = "book";
    
    public const string GetAll = $"{Controller}";
    public const string GetById = $"{Controller}/{{id:long}}";
    public const string Add = $"{Controller}";
    public const string Update = $"{Controller}/{{id:long}}";
    public const string Delete = $"{Controller}/{{id:long}}";
    public const string GetAvailableGrades = $"{Controller}/available-grades";
    public const string GetBooksByGrade = $"{Controller}/by-grade/{{grade}}";
    public const string GetLessonsByBookId = $"{Controller}/lessons/by-bookId/{{bookId:long}}";
}
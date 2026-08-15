namespace AzmoonYar.API.Constants;

public static class ExceptionLogUriConstants
{
    private const string Controller = "exception-log";
    
    public const string GetAll = $"{Controller}";
    public const string GetById = $"{Controller}/{{id:long}}";
    public const string GetRecent =  $"{Controller}/recent-count/{{count:int}}";
}
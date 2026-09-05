namespace AzmoonYar.API.Constants;

public static class UserUriConstants
{
    private const string Controller = "user";

    public const string Add = $"{Controller}";
    public const string Update = $"{Controller}/{{Id:long}}";
    public const string GetById = $"{Controller}/{{Id:long}}";
    public const string Login = $"{Controller}/login";
}
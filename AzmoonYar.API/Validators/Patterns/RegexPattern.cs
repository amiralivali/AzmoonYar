namespace AzmoonYar.API.FluentValidation.Patterns;

public static class RegexPattern
{
    public const string Username = @"^[a-zA-Z0-9_]+$";
    public const string BookName = @"^[a-zA-Z0-9آ-ی\s]+$";
    public const string LessonName = @"^[a-zA-Z0-9آ-ی\s]+$";
    public const string PersianOrEnglishLetters = @"^[a-zA-Zآ-ی\s]+$";
    public const string PersianLettersOnly = @"^[آ-ی\s]+$";
    public const string EnglishLettersOnly = @"^[a-zA-Z\s]+$";
    public const string MobileNumber = @"^09[0-9]{9}$";
    public const string PasswordUppercase = @"[A-Z]";
    public const string PasswordLowercase = @"[a-z]";
    public const string PasswordDigit = @"[0-9]";
    public const string PasswordSpecialChar = @"[\W_]";
}
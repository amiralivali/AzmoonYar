using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.FluentValidation.Messages;

public static class LessonMessage
{
    public const string LessonNameInvalidFormat = "نام درس فقط باید شامل حروف و عدد باشد";
    private const string LessonNameMaxLengthInvalidTemplate = "نام درس نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string LessonNameMaxLengthInvalid => 
        string.Format(LessonNameMaxLengthInvalidTemplate, LessonConstants.LessonNameMaxLenght);
}
using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class LessonValidationMessages
{
    public const string LessonNameInvalidFormat = "نام درس فقط باید شامل حروف و عدد باشد";
    private const string LessonNameMaxLengthInvalidTemplate = "نام درس نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string LessonNameMaxLengthInvalid => 
        string.Format(LessonNameMaxLengthInvalidTemplate, LessonConstants.LessonNameMaxLenght);
}
using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class BookValidationMessages
{
    public const string BookNameRequired = "نام کتاب الزامی است";
    public const string BookNameInvalidFormat = "نام کتاب فقط باید شامل حروف و عدد باشد";
    private const string BookNameMaxLengthInvalidTemplate = "نام کتاب نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string BookNameMaxLengthInvalid => 
        string.Format(BookNameMaxLengthInvalidTemplate, BookConstants.BookNameMaxLength);
    
    public const string GradeRequired = "مقطع تحصیلی الزامی است";
    
    private const string GradeInfoMaxLengthInvalidTemplate = "توضیحات مقطع تحصیلی نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string GradeInfoMaxLengthInvalid => 
        string.Format(GradeInfoMaxLengthInvalidTemplate, BookConstants.GradeInfoMaxLenght);
    
}
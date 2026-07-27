using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class QuestionValidationMessages
{
    public const string QuestionTextRequired = "متن سوال الزامی است";
    private const string QuestionTextMaxLengthInvalidTemplate = "متن سوال نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string QuestionTextMaxLengthInvalid => 
        string.Format(QuestionTextMaxLengthInvalidTemplate, BaseQuestionConstants.QuestionTextMaxLength);

    public const string QuestionTypeRequired = "نوع سوال الزامی است";

    public const string DifficultyLevelRequired = "سطح سوال الزامی است";
    
    private const string PictureMaxLengthInvalidTemplate = "رشته عکس نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string PictureMaxLengthInvalid => 
        string.Format(PictureMaxLengthInvalidTemplate, BaseQuestionConstants.PictureMaxLenght);
}
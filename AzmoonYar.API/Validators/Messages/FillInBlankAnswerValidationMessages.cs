using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class FillInBlankAnswerValidationMessages
{
    public const string AnswerRequired = "پاسخ الزامی است";
    private const string AnswerMaxLengthInvalidTemplate = "پاسخ نمیتواند بیشتر از {0} کاراکتر باشد";

    public static string AnswerMaxLengthInvalid =>
        string.Format(AnswerMaxLengthInvalidTemplate, FillInBlankAnswerConstants.MaxAnswerLength);
}
using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class TrueFalseItemValidationMessages
{
    public const string ItemTextRequired = "متن آیتم الزامی است";
    private const string ItemTextMaxLengthInvalidTemplate = "متن آیتم نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string ItemTextMaxLengthInvalid => 
        string.Format(ItemTextMaxLengthInvalidTemplate, TrueFalseItemConstants.ItemTextMaxLength);
}
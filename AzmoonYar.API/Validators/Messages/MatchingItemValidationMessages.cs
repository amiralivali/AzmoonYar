using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class MatchingItemValidationMessages
{
    public const string LeftItemTextRequired = "متن آیتم چپ الزامی است";
    private const string LeftItemTextMaxLengthInvalidTemplate = "متن آیتم چپ نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string LeftItemTextMaxLengthInvalid => 
        string.Format(LeftItemTextMaxLengthInvalidTemplate, MatchingItemConstants.LeftItemTextMaxLength);
    
    public const string RightItemTextRequired = "متن آیتم راست الزامی است";
    private const string RightItemTextMaxLengthInvalidTemplate = "متن آیتم راست نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string RightItemTextMaxLengthInvalid => 
        string.Format(RightItemTextMaxLengthInvalidTemplate, MatchingItemConstants.RightItemTextMaxLength);
}
using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class OptionalItemValidationMessages
{
    public const string Option1Required = "گزینه 1 الزامی است";
    private const string Option1MaxLengthInvalidTemplate = "متن آیتم نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string Option1MaxLengthInvalid => 
        string.Format(Option1MaxLengthInvalidTemplate, OptionalItemConstants.Option1MaxLength);
    
    public const string Option2Required = "گزینه 2 الزامی است";
    private const string Option2MaxLengthInvalidTemplate = "متن آیتم نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string Option2MaxLengthInvalid => 
        string.Format(Option2MaxLengthInvalidTemplate, OptionalItemConstants.Option2MaxLength);

    public const string Option3Required = "گزینه 3 الزامی است";
    private const string Option3MaxLengthInvalidTemplate = "متن آیتم نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string Option3MaxLengthInvalid => 
        string.Format(Option3MaxLengthInvalidTemplate, OptionalItemConstants.Option3MaxLength);

    public const string Option4Required = "گزینه 4 الزامی است";
    private const string Option4MaxLengthInvalidTemplate = "متن آیتم نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string Option4MaxLengthInvalid => 
        string.Format(Option4MaxLengthInvalidTemplate, OptionalItemConstants.Option4MaxLength);
}
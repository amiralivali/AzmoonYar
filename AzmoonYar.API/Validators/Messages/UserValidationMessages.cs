using AzmoonYar.Domain.Constants;

namespace AzmoonYar.API.Validators.Messages;

public static class UserValidationMessages
{
    public const string PhoneNumberRequired = "شماره تلفن الزامی است";
    
    public const string FirstNameRequired = "نام الزامی است";
    public const string FirstNameInvalidFormat = "نام فقط باید شامل حروف باشد";
    private const string FirstNameMaxLengthInvalidTemplate = "نام نمیتواند بیشتر از {0} کاراکتر باشد";
    public static string FirstNameMaxLengthInvalid => 
        string.Format(FirstNameMaxLengthInvalidTemplate, UserConstants.FirstNameMaxLength);
    
    public const string LastNameRequired = "نام خانوادگی الزامی است";
    public const string LastNameInvalidFormat = "نام خانوادگی فقط باید شامل حروف باشد";
    private const string LastNameMaxLengthInvalidTemplate = "نام خانوادگی نمیتواند بیشتر از {0} کاراکتر باشد.";
    public static string LastNameMaxLengthInvalid => 
        string.Format(LastNameMaxLengthInvalidTemplate, UserConstants.LastNameMaxLength);

    public const string PasswordRequired = "رمز عبور الزامی است";
    private const string PasswordLengthInvalidTemplate = "رمز عبور باید بین {0} تا {1} کاراکتر باشد";
    public static string PasswordLengthInvalid => 
        string.Format(PasswordLengthInvalidTemplate, UserConstants.PasswordMinLength,UserConstants.PasswordMaxLength);
    public const string PasswordMissingUppercase = "رمز عبور باید حداقل یک حرف بزرگ داشته باشد";
    public const string PasswordMissingLowercase = "رمز عبور باید حداقل یک حرف کوچک داشته باشد";
    public const string PasswordMissingDigit = "رمز عبور باید حداقل یک عدد داشته باشد";
    public const string PasswordMissingSpecialChar = "رمز عبور باید حداقل یک کاراکتر خاص داشته باشد";

    public const string EmailInvalid = "ایمیل نامعتبر میباشد";
}
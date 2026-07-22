using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.FluentValidation.Messages;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.FluentValidation.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(UserMessage.FirstNameRequired)
            .MaximumLength(UserConstants.FirstNameMaxLength).WithMessage(UserMessage.FirstNameMaxLengthInvalid)
            .Matches(RegexPattern.PersianOrEnglishLetters).WithMessage(UserMessage.FirstNameInvalidFormat);
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(UserMessage.LastNameRequired)
            .MaximumLength(UserConstants.LastNameMaxLength).WithMessage(UserMessage.LastNameMaxLengthInvalid)
            .Matches(RegexPattern.PersianOrEnglishLetters).WithMessage(UserMessage.LastNameInvalidFormat);
        
        RuleFor(x => x.UserName)
            .Length(UserConstants.UsernameMinLength, UserConstants.UsernameMaxLength)
            .Matches(RegexPattern.Username).WithMessage(UserMessage.UsernameInvalidFormat);
        
        RuleFor(x => x.Password)
            .Length(UserConstants.PasswordMinLength, UserConstants.PasswordMaxLength)
            .Matches(RegexPattern.PasswordUppercase).WithMessage(UserMessage.PasswordMissingUppercase)
            .Matches(RegexPattern.PasswordLowercase).WithMessage(UserMessage.PasswordMissingLowercase)
            .Matches(RegexPattern.PasswordDigit).WithMessage(UserMessage.PasswordMissingDigit)
            .Matches(RegexPattern.PasswordSpecialChar).WithMessage(UserMessage.PasswordMissingSpecialChar);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(UserMessage.PhoneNumberRequired)
            .MaximumLength(UserConstants.PhoneNumberMaxLength)
            .Matches(RegexPattern.MobileNumber);
    }
}
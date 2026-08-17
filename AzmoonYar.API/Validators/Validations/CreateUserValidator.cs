using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(UserValidationMessages.FirstNameRequired)
            .MaximumLength(UserConstants.FirstNameMaxLength).WithMessage(UserValidationMessages.FirstNameMaxLengthInvalid)
            .Matches(RegexPattern.PersianOrEnglishLetters).WithMessage(UserValidationMessages.FirstNameInvalidFormat);
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(UserValidationMessages.LastNameRequired)
            .MaximumLength(UserConstants.LastNameMaxLength).WithMessage(UserValidationMessages.LastNameMaxLengthInvalid)
            .Matches(RegexPattern.PersianOrEnglishLetters).WithMessage(UserValidationMessages.LastNameInvalidFormat);

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(UserValidationMessages.EmailInvalid);
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserValidationMessages.PasswordRequired)
            .Length(UserConstants.PasswordMinLength, UserConstants.PasswordMaxLength).WithMessage(UserValidationMessages.PasswordLengthInvalid)
            .Matches(RegexPattern.PasswordUppercase).WithMessage(UserValidationMessages.PasswordMissingUppercase)
            .Matches(RegexPattern.PasswordLowercase).WithMessage(UserValidationMessages.PasswordMissingLowercase)
            .Matches(RegexPattern.PasswordDigit).WithMessage(UserValidationMessages.PasswordMissingDigit)
            .Matches(RegexPattern.PasswordSpecialChar).WithMessage(UserValidationMessages.PasswordMissingSpecialChar);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(UserValidationMessages.PhoneNumberRequired)
            .MaximumLength(UserConstants.PhoneNumberMaxLength)
            .Matches(RegexPattern.MobileNumber);
    }
}
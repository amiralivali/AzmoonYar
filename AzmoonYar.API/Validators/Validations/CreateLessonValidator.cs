using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateLessonValidator : AbstractValidator<CreateLessonRequest>
{
    public CreateLessonValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(LessonConstants.LessonNameMaxLenght)
            .WithMessage(LessonValidationMessages.LessonNameMaxLengthInvalid)
            .Matches(RegexPattern.LessonName)
            .WithMessage(LessonValidationMessages.LessonNameInvalidFormat);
    }
}
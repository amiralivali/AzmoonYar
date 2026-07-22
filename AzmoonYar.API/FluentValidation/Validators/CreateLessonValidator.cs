using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.FluentValidation.Messages;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.FluentValidation.Validators;

public class CreateLessonValidator : AbstractValidator<CreateLessonRequest>
{
    public CreateLessonValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(LessonConstants.LessonNameMaxLenght)
            .WithMessage(LessonMessage.LessonNameMaxLengthInvalid)
            .Matches(RegexPattern.LessonName)
            .WithMessage(LessonMessage.LessonNameInvalidFormat);
    }
}
using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateBookValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.BookName)
            .NotEmpty().WithMessage(BookValidationMessages.BookNameRequired)
            .MaximumLength(BookConstants.BookNameMaxLength).WithMessage(BookValidationMessages.BookNameMaxLengthInvalid)
            .Matches(RegexPattern.BookName).WithMessage(BookValidationMessages.BookNameInvalidFormat);
        
        RuleFor(x => x.Grade)
            .NotEmpty()
            .WithMessage(BookValidationMessages.GradeRequired);
        
        When(x => x.Picture is not null, () =>
        {
            RuleFor(x => x.Picture!.Length)
                .LessThanOrEqualTo(BookConstants.MaxPictureFileSizeInBytes)
                .WithMessage(BookValidationMessages.MaxPictureSize);

            RuleFor(x => x.Picture!.FileName)
                .Must(fileName => BookConstants.AllowedPictureExtensions.Contains(Path.GetExtension(fileName).ToLowerInvariant()))
                .WithMessage(BookValidationMessages.AllowedPictureExtensions);
        });
        
        RuleForEach(x => x.LessonRequests)
            .SetValidator(new CreateLessonValidator());
    }
}
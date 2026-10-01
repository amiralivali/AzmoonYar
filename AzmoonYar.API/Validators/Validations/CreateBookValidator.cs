using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.API.Validators.Patterns;
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
        
        RuleFor(x => x.LessonRequests)
            .NotEmpty()
            .WithMessage("کتاب باید حداقل یک درس داشته باشد.");

        RuleFor(x => x.LessonRequests)
            .Must(lessons => lessons.Select(l => l.LessonNumber).Distinct().Count() == lessons.Count)
            .WithMessage("شماره دروس نباید تکراری باشد.");
        
        RuleForEach(x => x.LessonRequests)
            .SetValidator(new CreateLessonValidator());
    }
}
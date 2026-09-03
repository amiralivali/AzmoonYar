using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.BookName)
            .NotEmpty().WithMessage(BookValidationMessages.BookNameRequired)
            .MaximumLength(BookConstants.BookNameMaxLength).WithMessage(BookValidationMessages.BookNameMaxLengthInvalid)
            .Matches(RegexPattern.BookName).WithMessage(BookValidationMessages.BookNameInvalidFormat);
        
        RuleFor(x => x.Grade)
            .NotEmpty()
            .WithMessage(BookValidationMessages.GradeRequired);
        
        RuleFor(x=>x.BookSource)
            .NotEmpty()
            .WithMessage(BookValidationMessages.BookSourceRequired);
        
        RuleForEach(x => x.UpdateLessonRequests)
            .SetValidator(new UpdateLessonValidator());
    }
}
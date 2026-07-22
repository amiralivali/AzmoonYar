using AzmoonYar.API.Contracts.Book;
using AzmoonYar.API.FluentValidation.Messages;
using AzmoonYar.API.FluentValidation.Patterns;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.FluentValidation.Validators;

public class CreateBookValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.BookName)
            .NotEmpty().WithMessage(BookMessages.BookNameRequired)
            .MaximumLength(BookConstants.BookNameMaxLength).WithMessage(BookMessages.BookNameMaxLengthInvalid)
            .Matches(RegexPattern.BookName).WithMessage(BookMessages.BookNameInvalidFormat);
        
        RuleFor(x => x.Grade)
            .NotEmpty()
            .WithMessage(BookMessages.GradeRequired);
        
        RuleFor(x=>x.GradeInfo)
            .MaximumLength(BookConstants.GradeInfoMaxLenght)
            .WithMessage(BookMessages.GradeInfoMaxLengthInvalid);
        
        RuleForEach(x => x.LessonRequests)
            .SetValidator(new CreateLessonValidator());
    }
}
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateFillInBlankAnswerValidator : AbstractValidator<CreateFillInBlankAnswerRequest>
{
    public CreateFillInBlankAnswerValidator()
    {
        RuleFor(x=>x.Answer)
            .NotEmpty().WithMessage(FillInBlankAnswerValidationMessages.AnswerRequired)
            .MaximumLength(FillInBlankAnswerConstants.MaxAnswerLength)
            .WithMessage(FillInBlankAnswerValidationMessages.AnswerMaxLengthInvalid);
    }
}
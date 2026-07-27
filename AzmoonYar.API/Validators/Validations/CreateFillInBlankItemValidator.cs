using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateFillInBlankItemValidator : AbstractValidator<CreateFillInBlankItemRequest>
{
    public CreateFillInBlankItemValidator()
    {
        RuleFor(x => x.ItemText)
            .NotEmpty().WithMessage(FillInBlankItemValidationMessages.ItemTextRequired)
            .MaximumLength(FillInBlankItemConstants.ItemTextMaxLength)
            .WithMessage(FillInBlankItemValidationMessages.ItemTextMaxLengthInvalid);
    }
}
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateTrueFalseItemValidator : AbstractValidator<CreateTrueFalseItemRequest>
{
    public CreateTrueFalseItemValidator()
    {
        RuleFor(x => x.ItemText)
            .NotEmpty().WithMessage(TrueFalseItemValidationMessages.ItemTextRequired)
            .MaximumLength(TrueFalseItemConstants.ItemTextMaxLength)
            .WithMessage(TrueFalseItemValidationMessages.ItemTextMaxLengthInvalid);
    }
}
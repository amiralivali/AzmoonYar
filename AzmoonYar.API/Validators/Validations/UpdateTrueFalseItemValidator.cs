using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Contracts.TrueFalseItem;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class UpdateTrueFalseItemValidator : AbstractValidator<UpdateTrueFalseItemRequest>
{
    public UpdateTrueFalseItemValidator()
    {
        RuleFor(x => x.ItemText)
            .NotEmpty().WithMessage(TrueFalseItemValidationMessages.ItemTextRequired)
            .MaximumLength(TrueFalseItemConstants.ItemTextMaxLength)
            .WithMessage(TrueFalseItemValidationMessages.ItemTextMaxLengthInvalid);
    }
}
using AzmoonYar.API.Contracts.OptionalItem;
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class UpdateOptionalItemValidator : AbstractValidator<UpdateOptionalItemRequest>
{
    public UpdateOptionalItemValidator()
    {
        RuleFor(x => x.Option1)
            .NotEmpty().WithMessage(OptionalItemValidationMessages.Option1Required)
            .MaximumLength(OptionalItemConstants.Option1MaxLength)
            .WithMessage(OptionalItemValidationMessages.Option1MaxLengthInvalid);
        
        RuleFor(x => x.Option2)
            .NotEmpty().WithMessage(OptionalItemValidationMessages.Option2Required)
            .MaximumLength(OptionalItemConstants.Option2MaxLength)
            .WithMessage(OptionalItemValidationMessages.Option2MaxLengthInvalid);
        
        RuleFor(x => x.Option3)
            .NotEmpty().WithMessage(OptionalItemValidationMessages.Option3Required)
            .MaximumLength(OptionalItemConstants.Option3MaxLength)
            .WithMessage(OptionalItemValidationMessages.Option3MaxLengthInvalid);
        
        RuleFor(x => x.Option4)
            .NotEmpty().WithMessage(OptionalItemValidationMessages.Option4Required)
            .MaximumLength(OptionalItemConstants.Option4MaxLength)
            .WithMessage(OptionalItemValidationMessages.Option4MaxLengthInvalid);
    }
}
using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class UpdateMatchingItemValidator : AbstractValidator<UpdateMatchingItemRequest>
{
    public UpdateMatchingItemValidator()
    {
        RuleFor(x => x.LeftItemText)
            .NotEmpty().WithMessage(MatchingItemValidationMessages.LeftItemTextRequired)
            .MaximumLength(MatchingItemConstants.LeftItemTextMaxLength)
            .WithMessage(MatchingItemValidationMessages.LeftItemTextMaxLengthInvalid);
        
        RuleFor(x => x.RightItemText)
            .NotEmpty().WithMessage(MatchingItemValidationMessages.RightItemTextRequired)
            .MaximumLength(MatchingItemConstants.RightItemTextMaxLength)
            .WithMessage(MatchingItemValidationMessages.LeftItemTextMaxLengthInvalid);
    }
}
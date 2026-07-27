using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateMatchingQuestionValidator : AbstractValidator<CreateMatchingQuestionRequest>
{
    public CreateMatchingQuestionValidator()
    {
        RuleFor(x => x.QuestionText)
            .NotEmpty()
            .WithMessage(QuestionValidationMessages.QuestionTextRequired)
            .MaximumLength(BaseQuestionConstants.QuestionTextMaxLength)
            .WithMessage(QuestionValidationMessages.QuestionTextMaxLengthInvalid);
        
        RuleFor(x => x.Picture)
            .MaximumLength(BaseQuestionConstants.PictureMaxLenght)
            .WithMessage(QuestionValidationMessages.PictureMaxLengthInvalid);
        
        RuleFor(x => x.DifficultyLevel)
            .NotEmpty()
            .WithMessage(QuestionValidationMessages.DifficultyLevelRequired);
        
        RuleForEach(x=>x.MatchingItems)
            .SetValidator(new CreateMatchingItemValidator());
    }
}
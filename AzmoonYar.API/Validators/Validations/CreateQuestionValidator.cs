using AzmoonYar.API.Contracts.Question;
using AzmoonYar.API.Validators.Messages;
using AzmoonYar.Domain.Constants;
using FluentValidation;

namespace AzmoonYar.API.Validators.Validations;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionRequest>
{
    public CreateQuestionValidator()
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
        
        RuleFor(x=>x.QuestionType)
            .NotEmpty()
            .WithMessage(QuestionValidationMessages.QuestionTypeRequired);

        RuleFor(x => x.OptionalItem)
            .SetValidator(new CreateOptionalItemValidator()!);

        RuleForEach(x => x.FillInBlankItems)
            .SetValidator(new CreateFillInBlankItemValidator());
        
        RuleForEach(x => x.TrueFalseItems)
            .SetValidator(new CreateTrueFalseItemValidator());
        
        RuleForEach(x => x.MatchingItems)
            .SetValidator(new CreateMatchingItemValidator());
    }
}
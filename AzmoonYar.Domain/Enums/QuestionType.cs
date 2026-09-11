using System.ComponentModel.DataAnnotations;

namespace AzmoonYar.Domain.Enums;

public enum QuestionType
{
    [Display(Name = "تشریحی")]
    Descriptive = 1,
    
    [Display(Name = "جاخالی")]
    FillInBlank = 2,
    
    [Display(Name = "وصل کردنی")]
    Matching = 3,
    
    [Display(Name = "تستی")]
    Optional = 4,
    
    [Display(Name = "کوتاه پاسخ")]
    ShortAnswer = 5,
    
    [Display(Name = "صحیح غلط")]
    TrueFalse = 6
}
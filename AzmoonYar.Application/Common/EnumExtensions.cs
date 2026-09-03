using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Common;

public static class EnumExtensions
{
    public static string ToPersian(this Grade grade)
    {
        return grade switch
        {
            Grade.ElementaryFirst => "اول ابتدایی",
            Grade.ElementarySecond => "دوم ابتدایی",
            Grade.ElementaryThird => "سوم ابتدایی",
            Grade.ElementaryFourth => "چهارم ابتدایی",
            Grade.ElementaryFifth => "پنجم ابتدایی",
            Grade.ElementarySixth => "ششم ابتدایی",
            Grade.MiddleSchoolSeventh => "هفتم متوسطه اول",
            Grade.MiddleSchoolEighth => "هشتم متوسطه اول",
            Grade.MiddleSchoolNinth => "نهم متوسطه اول",
            Grade.HighSchoolTenth => "دهم متوسطه دوم",
            Grade.HighSchoolEleventh => "یازدهم متوسطه دوم",
            Grade.HighSchoolTwelfth => "دوازدهم متوسطه دوم",
            Grade.University => "دانشگاه",
            Grade.More => "سایر",
            _ => grade.ToString()
        };
    }
    
    public static string ToPersian(this QuestionType questionType)
    {
        return questionType switch
        {
            QuestionType.Descriptive => "تشریحی",
            QuestionType.ShortAnswer => "کوتاه پاسخ",
            QuestionType.FillInBlank => "جاخالی",
            QuestionType.Matching => "وصل کردنی",
            QuestionType.Optional => "تستی",
            QuestionType.TrueFalse => "صحیح غلط",
            _ => questionType.ToString()
        };
    }
}
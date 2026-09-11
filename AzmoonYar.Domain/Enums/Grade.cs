using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzmoonYar.Domain.Enums;

public enum Grade
{
    [Display(Name = "اول ابتدایی")]
    ElementaryFirst = 1,

    [Display(Name = "دوم ابتدایی")]
    ElementarySecond = 2,

    [Display(Name = "سوم ابتدایی")]
    ElementaryThird = 3,

    [Display(Name = "چهارم ابتدایی")]
    ElementaryFourth = 4,

    [Display(Name = "پنجم ابتدایی")]
    ElementaryFifth = 5,

    [Display(Name = "ششم ابتدایی")]
    ElementarySixth = 6,

    [Display(Name = "هفتم متوسطه اول")]
    MiddleSchoolSeventh = 7,

    [Display(Name = "هشتم متوسطه اول")]
    MiddleSchoolEighth = 8,

    [Display(Name = "نهم متوسطه اول")]
    MiddleSchoolNinth = 9,

    [Display(Name = "دهم متوسطه دوم")]
    HighSchoolTenth = 10,

    [Display(Name = "یازدهم متوسطه دوم")]
    HighSchoolEleventh = 11,

    [Display(Name = "دوازدهم متوسطه دوم")]
    HighSchoolTwelfth = 12,

    [Display(Name = "دانشگاه")]
    University = 13,

    [Display(Name = "سایر")]
    More = 14
}
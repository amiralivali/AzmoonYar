using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Seed;

public class LessonSeed
{
    private static readonly DateTimeOffset CreatedAt =
        new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>().HasData(

            // =========================
            // ریاضی اول ابتدایی
            // =========================

            new
            {
                Id = 100001L,
                LessonName = "فصل 1",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 100002L,
                LessonName = "فصل 2",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 100003L,
                LessonName = "فصل 3",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 100004L,
                LessonName = "فصل 4",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 100005L,
                LessonName = "فصل 5",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 100006L,
                LessonName = "فصل 6",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 100007L,
                LessonName = "فصل 7",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 100008L,
                LessonName = "فصل 8",
                Title = (string?)null,
                BookId = SystemBookIds.FirstGradeMath,
                LessonCount = 8,
                CreatedAt
            },

            // =========================
            // علوم تجربی اول ابتدایی
            // =========================

            new
            {
                Id = 100101L,
                LessonName = "زنگ علوم",
                Title = "زنگ علوم",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 100102L,
                LessonName = "سلام، به من نگاه کن!",
                Title = "سلام، به من نگاه کن!",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 100103L,
                LessonName = "سالم باش، شاداب باش",
                Title = "سالم باش، شاداب باش",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 100104L,
                LessonName = "دنیای جانوران",
                Title = "دنیای جانوران",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 100105L,
                LessonName = "دنیای گیاهان",
                Title = "دنیای گیاهان",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 100106L,
                LessonName = "زمین خانه‌ی پرآب ما",
                Title = "زمین خانه‌ی پرآب ما",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 100107L,
                LessonName = "زمین خانه‌ی سنگی ما",
                Title = "زمین خانه‌ی سنگی ما",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 100108L,
                LessonName = "چه می‌خواهم بسازم؟",
                Title = "چه می‌خواهم بسازم؟",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 100109L,
                LessonName = "زمین خانه‌ی خاکی ما",
                Title = "زمین خانه‌ی خاکی ما",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 100110L,
                LessonName = "در اطراف ما هوا وجود دارد",
                Title = "در اطراف ما هوا وجود دارد",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 100111L,
                LessonName = "دنیای سرد و گرم",
                Title = "دنیای سرد و گرم",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 100112L,
                LessonName = "از خانه تا مدرسه",
                Title = "از خانه تا مدرسه",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 100113L,
                LessonName = "آهن‌ربای من",
                Title = "آهن‌ربای من",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 100114L,
                LessonName = "از گذشته تا آینده",
                Title = "از گذشته تا آینده",
                BookId = SystemBookIds.FirstGradeScience,
                LessonCount = 14,
                CreatedAt
            },

            // =========================
            // فارسی اول ابتدایی
            // =========================

            new
            {
                Id = 100201L,
                LessonName = "نگاره‌ها",
                Title = "نگاره‌ها",
                BookId = SystemBookIds.FirstGradePersian,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 100202L,
                LessonName = "آموزش نشانه‌ها 1",
                Title = "آموزش نشانه‌ها 1",
                BookId = SystemBookIds.FirstGradePersian,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 100203L,
                LessonName = "آموزش نشانه‌ها 2",
                Title = "آموزش نشانه‌ها 2",
                BookId = SystemBookIds.FirstGradePersian,
                LessonCount = 3,
                CreatedAt
            },

            // =========================
            // نگارش فارسی اول ابتدایی
            // =========================

            new
            {
                Id = 100301L,
                LessonName = "نگاره‌ها",
                Title = "نگاره‌ها",
                BookId = SystemBookIds.FirstGradePersianWriting,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 100302L,
                LessonName = "درس‌های 1 تا 15",
                Title = "درس‌های 1 تا 15",
                BookId = SystemBookIds.FirstGradePersianWriting,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 100303L,
                LessonName = "تمرین‌های دوره‌ای 1",
                Title = "تمرین‌های دوره‌ای 1",
                BookId = SystemBookIds.FirstGradePersianWriting,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 100304L,
                LessonName = "درس‌های 16 تا 22",
                Title = "درس‌های 16 تا 22",
                BookId = SystemBookIds.FirstGradePersianWriting,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 100305L,
                LessonName = "تمرین‌های دوره‌ای 2",
                Title = "تمرین‌های دوره‌ای 2",
                BookId = SystemBookIds.FirstGradePersianWriting,
                LessonCount = 5,
                CreatedAt
            },

            // =========================
            // آموزش قرآن اول ابتدایی
            // =========================

            new
            {
                Id = 100401L,
                LessonName = "درس 1: به نام خدا، بسم‌الله",
                Title = "به نام خدا، بسم‌الله",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 100402L,
                LessonName = "درس 2: نعمت‌های خدا",
                Title = "نعمت‌های خدا",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 100403L,
                LessonName = "درس 3: خانه ما",
                Title = "خانه ما",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 100404L,
                LessonName = "درس 4: قرآن بخوانیم",
                Title = "قرآن بخوانیم",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 100405L,
                LessonName = "درس 5: کودک مسلمان",
                Title = "کودک مسلمان",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 100406L,
                LessonName = "درس 6: مدرسه ما",
                Title = "مدرسه ما",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 100407L,
                LessonName = "درس 7: پیامبران خدا",
                Title = "پیامبران خدا",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 100408L,
                LessonName = "درس 8: در تابستان نیز قرآن بخوانیم",
                Title = "در تابستان نیز قرآن بخوانیم",
                BookId = SystemBookIds.FirstGradeQuran,
                LessonCount = 8,
                CreatedAt
            },
            // =====================================================
            // ریاضی دوم ابتدایی - 8 فصل
            // =====================================================

            new
            {
                Id = 200001L,
                LessonName = "فصل 1",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200002L,
                LessonName = "فصل 2",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200003L,
                LessonName = "فصل 3",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200004L,
                LessonName = "فصل 4",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200005L,
                LessonName = "فصل 5",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200006L,
                LessonName = "فصل 6",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200007L,
                LessonName = "فصل 7",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200008L,
                LessonName = "فصل 8",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeMath,
                LessonCount = 8,
                CreatedAt
            },

            // =====================================================
            // علوم تجربی دوم ابتدایی - 14 درس
            // =====================================================

            new
            {
                Id = 200101L,
                LessonName = "زنگ علوم",
                Title = "زنگ علوم",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200102L,
                LessonName = "هوای سالم، آب سالم",
                Title = "هوای سالم، آب سالم",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200103L,
                LessonName = "زندگی ما و گردش زمین 1",
                Title = "زندگی ما و گردش زمین 1",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200104L,
                LessonName = "زندگی ما و گردش زمین 2",
                Title = "زندگی ما و گردش زمین 2",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200105L,
                LessonName = "پیام رمز را پیدا کن 1",
                Title = "پیام رمز را پیدا کن 1",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200106L,
                LessonName = "پیام رمز را پیدا کن 2",
                Title = "پیام رمز را پیدا کن 2",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200107L,
                LessonName = "اگر تمام شود…",
                Title = "اگر تمام شود…",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200108L,
                LessonName = "بسازیم و لذت ببریم",
                Title = "بسازیم و لذت ببریم",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 200109L,
                LessonName = "سرگذشت دانه",
                Title = "سرگذشت دانه",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 200110L,
                LessonName = "درون آشیانه‌ها",
                Title = "درون آشیانه‌ها",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 200111L,
                LessonName = "من رشد می‌کنم",
                Title = "من رشد می‌کنم",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 200112L,
                LessonName = "برای جشن آماده شویم",
                Title = "برای جشن آماده شویم",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 200113L,
                LessonName = "بعد از جشن",
                Title = "بعد از جشن",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 200114L,
                LessonName = "از گذشته تا آینده",
                Title = "از گذشته تا آینده",
                BookId = SystemBookIds.SecondGradeScience,
                LessonCount = 14,
                CreatedAt
            },

            // =====================================================
            // فارسی دوم ابتدایی - 17 درس
            // =====================================================

            new
            {
                Id = 200201L,
                LessonName = "درس 1: کتابخانه‌ی کلاس ما",
                Title = "کتابخانه‌ی کلاس ما",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200202L,
                LessonName = "درس 2: مسجد محله‌ی ما",
                Title = "مسجد محله‌ی ما",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200203L,
                LessonName = "درس 3: خرس کوچولو",
                Title = "خرس کوچولو",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200204L,
                LessonName = "درس 4: مدرسه‌ی خرگوش‌ها",
                Title = "مدرسه‌ی خرگوش‌ها",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200205L,
                LessonName = "درس 5: چوپان درستکار",
                Title = "چوپان درستکار",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200206L,
                LessonName = "درس 6: کوشا و نوشا",
                Title = "کوشا و نوشا",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200207L,
                LessonName = "درس 7: دوستان ما",
                Title = "دوستان ما",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200208L,
                LessonName = "درس 8: از همه مهربان‌تر",
                Title = "از همه مهربان‌تر",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 200209L,
                LessonName = "درس 9: زیارت",
                Title = "زیارت",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 200210L,
                LessonName = "درس 10: هنرمند",
                Title = "هنرمند",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 200211L,
                LessonName = "درس 11: درس آزاد",
                Title = "درس آزاد",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 200212L,
                LessonName = "درس 12: فردوسی",
                Title = "فردوسی",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 200213L,
                LessonName = "درس 13: ایران زیبا",
                Title = "ایران زیبا",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 200214L,
                LessonName = "درس 14: پرچم",
                Title = "پرچم",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 14,
                CreatedAt
            },
            new
            {
                Id = 200215L,
                LessonName = "درس 15: نوروز",
                Title = "نوروز",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 15,
                CreatedAt
            },
            new
            {
                Id = 200216L,
                LessonName = "درس 16: پرواز قطره",
                Title = "پرواز قطره",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 16,
                CreatedAt
            },
            new
            {
                Id = 200217L,
                LessonName = "درس 17: مثل دانشمندان",
                Title = "مثل دانشمندان",
                BookId = SystemBookIds.SecondGradePersian,
                LessonCount = 17,
                CreatedAt
            },

            // =====================================================
            // نگارش فارسی دوم ابتدایی - 17 درس
            // =====================================================

            new
            {
                Id = 200301L,
                LessonName = "درس 1: کتابخانه‌ی کلاس ما",
                Title = "کتابخانه‌ی کلاس ما",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200302L,
                LessonName = "درس 2: مسجد محله‌ی ما",
                Title = "مسجد محله‌ی ما",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200303L,
                LessonName = "درس 3: خرس کوچولو",
                Title = "خرس کوچولو",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200304L,
                LessonName = "درس 4: مدرسه‌ی خرگوش‌ها",
                Title = "مدرسه‌ی خرگوش‌ها",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200305L,
                LessonName = "درس 5: چوپان درستکار",
                Title = "چوپان درستکار",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200306L,
                LessonName = "درس 6: کوشا و نوشا",
                Title = "کوشا و نوشا",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200307L,
                LessonName = "درس 7: دوستان ما",
                Title = "دوستان ما",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200308L,
                LessonName = "درس 8: از همه مهربان‌تر",
                Title = "از همه مهربان‌تر",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 200309L,
                LessonName = "درس 9: زیارت",
                Title = "زیارت",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 200310L,
                LessonName = "درس 10: هنرمند",
                Title = "هنرمند",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 200311L,
                LessonName = "درس 11: درس آزاد",
                Title = "درس آزاد",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 200312L,
                LessonName = "درس 12: فردوسی",
                Title = "فردوسی",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 200313L,
                LessonName = "درس 13: ایران زیبا",
                Title = "ایران زیبا",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 200314L,
                LessonName = "درس 14: پرچم",
                Title = "پرچم",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 14,
                CreatedAt
            },
            new
            {
                Id = 200315L,
                LessonName = "درس 15: نوروز",
                Title = "نوروز",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 15,
                CreatedAt
            },
            new
            {
                Id = 200316L,
                LessonName = "درس 16: پرواز قطره",
                Title = "پرواز قطره",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 16,
                CreatedAt
            },
            new
            {
                Id = 200317L,
                LessonName = "درس 17: مثل دانشمندان",
                Title = "مثل دانشمندان",
                BookId = SystemBookIds.SecondGradePersianWriting,
                LessonCount = 17,
                CreatedAt
            },

            // =====================================================
            // آموزش قرآن دوم ابتدایی - 14 درس
            // =====================================================

            new
            {
                Id = 200401L,
                LessonName = "درس 1",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200402L,
                LessonName = "درس 2",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200403L,
                LessonName = "درس 3",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200404L,
                LessonName = "درس 4",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200405L,
                LessonName = "درس 5",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200406L,
                LessonName = "درس 6",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200407L,
                LessonName = "درس 7",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200408L,
                LessonName = "درس 8",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 200409L,
                LessonName = "درس 9",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 200410L,
                LessonName = "درس 10",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 200411L,
                LessonName = "درس 11",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 200412L,
                LessonName = "درس 12",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 200413L,
                LessonName = "درس 13",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 200414L,
                LessonName = "درس 14",
                Title = (string?)null,
                BookId = SystemBookIds.SecondGradeQuran,
                LessonCount = 14,
                CreatedAt
            },

            // =====================================================
            // هدیه‌های آسمان دوم ابتدایی - 20 درس
            // =====================================================

            new
            {
                Id = 200501L,
                LessonName = "درس 1: هدیه‌های خدا",
                Title = "هدیه‌های خدا",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 200502L,
                LessonName = "درس 2: پرندگان چه می‌گویند؟",
                Title = "پرندگان چه می‌گویند؟",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 2,
                CreatedAt
            },
            new
            {
                Id = 200503L,
                LessonName = "درس 3: خاطره‌ی ماه",
                Title = "خاطره‌ی ماه",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 3,
                CreatedAt
            },
            new
            {
                Id = 200504L,
                LessonName = "درس 4: مهربان‌تر از مادر",
                Title = "مهربان‌تر از مادر",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 4,
                CreatedAt
            },
            new
            {
                Id = 200505L,
                LessonName = "درس 5: می‌خواهم وضو بگیرم",
                Title = "می‌خواهم وضو بگیرم",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 5,
                CreatedAt
            },
            new
            {
                Id = 200506L,
                LessonName = "درس 6: پیامبران خدا",
                Title = "پیامبران خدا",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 6,
                CreatedAt
            },
            new
            {
                Id = 200507L,
                LessonName = "درس 7: مهمان کوچک",
                Title = "مهمان کوچک",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 7,
                CreatedAt
            },
            new
            {
                Id = 200508L,
                LessonName = "درس 8: جشن میلاد",
                Title = "جشن میلاد",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 8,
                CreatedAt
            },
            new
            {
                Id = 200509L,
                LessonName = "درس 9: اهل بیت پیامبر",
                Title = "اهل بیت پیامبر",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 9,
                CreatedAt
            },
            new
            {
                Id = 200510L,
                LessonName = "درس 10: خانواده‌ی بخشنده",
                Title = "خانواده‌ی بخشنده",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 10,
                CreatedAt
            },
            new
            {
                Id = 200511L,
                LessonName = "درس 11: نماز بخوانیم",
                Title = "نماز بخوانیم",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 11,
                CreatedAt
            },
            new
            {
                Id = 200512L,
                LessonName = "درس 12: پدر مهربان",
                Title = "پدر مهربان",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 12,
                CreatedAt
            },
            new
            {
                Id = 200513L,
                LessonName = "درس 13: بهترین دوست",
                Title = "بهترین دوست",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 13,
                CreatedAt
            },
            new
            {
                Id = 200514L,
                LessonName = "درس 14: دعای باران",
                Title = "دعای باران",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 14,
                CreatedAt
            },
            new
            {
                Id = 200515L,
                LessonName = "درس 15: بچه‌ها سلام!",
                Title = "بچه‌ها سلام!",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 15,
                CreatedAt
            },
            new
            {
                Id = 200516L,
                LessonName = "درس 16: طبیعت زیبا",
                Title = "طبیعت زیبا",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 16,
                CreatedAt
            },
            new
            {
                Id = 200517L,
                LessonName = "درس 17: وقت نماز",
                Title = "وقت نماز",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 17,
                CreatedAt
            },
            new
            {
                Id = 200518L,
                LessonName = "درس 18: راز خوشبختی",
                Title = "راز خوشبختی",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 18,
                CreatedAt
            },
            new
            {
                Id = 200519L,
                LessonName = "درس 19: جشن بزرگ",
                Title = "جشن بزرگ",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 19,
                CreatedAt
            },
            new
            {
                Id = 200520L,
                LessonName = "درس 20: در کنار سفره",
                Title = "در کنار سفره",
                BookId = SystemBookIds.SecondGradeHeavenlyGifts,
                LessonCount = 20,
                CreatedAt
            },
            // =====================================================
            // Third Grade - Math
            // =====================================================
            
            new
            {
                Id = 300001L,
                LessonName = "فصل 1",
                Title = (string?)null,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 1,
                CreatedAt
            },
            new
            {
                Id = 300002L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 2,
                Title = (string?)null,
                LessonName = "فصل 2",
                CreatedAt
            },
            new
            {
                Id = 300003L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 3,
                Title = (string?)null,
                LessonName = "فصل 3",
                CreatedAt
            },
            new
            {
                Id = 300004L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 4,
                Title = (string?)null,
                LessonName = "فصل 4",
                CreatedAt
            },
            new
            {
                Id = 300005L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 5,
                Title = (string?)null,
                LessonName = "فصل 5",
                CreatedAt
            },
            new
            {
                Id = 300006L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 6,
                Title = (string?)null,
                LessonName = "فصل 6",
                CreatedAt
            },
            new
            {
                Id = 300007L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 7,
                Title = (string?)null,
                LessonName = "فصل 7",
                CreatedAt
            },
            new
            {
                Id = 300008L,
                BookId = SystemBookIds.ThirdGradeMath,
                LessonCount = 8,
                Title = (string?)null,
                LessonName = "فصل 8",
                CreatedAt
            },
            
            // =====================================================
            // Third Grade - Science
            // =====================================================
            
            new
            {
                Id = 300101L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 1,
                Title = "زنگ علوم",
                LessonName = "درس 1: زنگ علوم",
                CreatedAt
            },
            new
            {
                Id = 300102L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 2,
                Title = "خوراکی‌ها",
                LessonName = "درس 2: خوراکی‌ها",
                CreatedAt
            },
            new
            {
                Id = 300103L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 3,
                Title = "مواد اطراف ما",
                LessonName = "درس 3: مواد اطراف ما",
                CreatedAt
            },
            new
            {
                Id = 300104L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 4,
                Title = "اندازه‌گیری مواد",
                LessonName = "درس 4: اندازه‌گیری مواد",
                CreatedAt
            },
            new
            {
                Id = 300105L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 5,
                Title = "آب ماده با ارزش",
                LessonName = "درس 5: آب ماده با ارزش",
                CreatedAt
            },
            new
            {
                Id = 300106L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 6,
                Title = "زندگی ما و آب",
                LessonName = "درس 6: زندگی ما و آب",
                CreatedAt
            },
            new
            {
                Id = 300107L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 7,
                Title = "نور و مشاهده اجسام",
                LessonName = "درس 7: نور و مشاهده اجسام",
                CreatedAt
            },
            new
            {
                Id = 300108L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 8,
                Title = "جست‌وجو کنیم و بسازیم",
                LessonName = "درس 8: جست‌وجو کنیم و بسازیم",
                CreatedAt
            },
            new
            {
                Id = 300109L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 9,
                Title = "نیرو، همه‌جا (۱)",
                LessonName = "درس 9: نیرو، همه‌جا (۱)",
                CreatedAt
            },
            new
            {
                Id = 300110L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 10,
                Title = "نیرو، همه‌جا (۲)",
                LessonName = "درس 10: نیرو، همه‌جا (۲)",
                CreatedAt
            },
            new
            {
                Id = 300111L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 11,
                Title = "بکارید و ببینید",
                LessonName = "درس 11: بکارید و ببینید",
                CreatedAt
            },
            new
            {
                Id = 300112L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 12,
                Title = "هر کدام جای خود (۱)",
                LessonName = "درس 12: هر کدام جای خود (۱)",
                CreatedAt
            },
            new
            {
                Id = 300113L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 13,
                Title = "هر کدام جای خود (۲)",
                LessonName = "درس 13: هر کدام جای خود (۲)",
                CreatedAt
            },
            new
            {
                Id = 300114L,
                BookId = SystemBookIds.ThirdGradeScience,
                LessonCount = 14,
                Title = "از گذشته تا آینده",
                LessonName = "درس 14: از گذشته تا آینده",
                CreatedAt
            },
            
            // =====================================================
            // Third Grade - Persian
            // =====================================================
            
            new
            {
                Id = 300201L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 1,
                Title = "محله‌ی ما",
                LessonName = "درس 1: محله‌ی ما",
                CreatedAt
            },
            new
            {
                Id = 300202L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 2,
                Title = "زنگ ورزش",
                LessonName = "درس 2: زنگ ورزش",
                CreatedAt
            },
            new
            {
                Id = 300203L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 3,
                Title = "آسمان آبی، طبیعت پاک",
                LessonName = "درس 3: آسمان آبی، طبیعت پاک",
                CreatedAt
            },
            new
            {
                Id = 300204L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 4,
                Title = "آواز گنجشک",
                LessonName = "درس 4: آواز گنجشک",
                CreatedAt
            },
            new
            {
                Id = 300205L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 5,
                Title = "بلدرچین و برزگر",
                LessonName = "درس 5: بلدرچین و برزگر",
                CreatedAt
            },
            new
            {
                Id = 300206L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 6,
                Title = "فداکاران",
                LessonName = "درس 6: فداکاران",
                CreatedAt
            },
            new
            {
                Id = 300207L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 7,
                Title = "کار نیک",
                LessonName = "درس 7: کار نیک",
                CreatedAt
            },
            new
            {
                Id = 300208L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 8,
                Title = "پیراهن بهشتی",
                LessonName = "درس 8: پیراهن بهشتی",
                CreatedAt
            },
            new
            {
                Id = 300209L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 9,
                Title = "بوی نرگس",
                LessonName = "درس 9: بوی نرگس",
                CreatedAt
            },
            new
            {
                Id = 300210L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 10,
                Title = "یار مهربان",
                LessonName = "درس 10: یار مهربان",
                CreatedAt
            },
            new
            {
                Id = 300211L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 11,
                Title = "نویسنده‌ی بزرگ",
                LessonName = "درس 11: نویسنده‌ی بزرگ",
                CreatedAt
            },
            new
            {
                Id = 300212L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 12,
                Title = "ایران عزیز",
                LessonName = "درس 12: ایران عزیز",
                CreatedAt
            },
            new
            {
                Id = 300213L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 13,
                Title = "درس آزاد",
                LessonName = "درس 13: درس آزاد",
                CreatedAt
            },
            new
            {
                Id = 300214L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 14,
                Title = "ایران آباد",
                LessonName = "درس 14: ایران آباد",
                CreatedAt
            },
            new
            {
                Id = 300215L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 15,
                Title = "دریا",
                LessonName = "درس 15: دریا",
                CreatedAt
            },
            new
            {
                Id = 300216L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 16,
                Title = "اگر جنگل نباشد",
                LessonName = "درس 16: اگر جنگل نباشد",
                CreatedAt
            },
            new
            {
                Id = 300217L,
                BookId = SystemBookIds.ThirdGradePersian,
                LessonCount = 17,
                Title = "چشم‌های آسمان",
                LessonName = "درس 17: چشم‌های آسمان",
                CreatedAt
            },
            
            // =====================================================
            // Third Grade - Persian Writing
            // =====================================================
            
            new
            {
                Id = 300301L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 1,
                Title = "محله‌ی ما",
                LessonName = "درس 1: محله‌ی ما",
                CreatedAt
            },
            new
            {
                Id = 300302L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 2,
                Title = "زنگ ورزش",
                LessonName = "درس 2: زنگ ورزش",
                CreatedAt
            },
            new
            {
                Id = 300303L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 3,
                Title = "آسمان آبی، طبیعت پاک",
                LessonName = "درس 3: آسمان آبی، طبیعت پاک",
                CreatedAt
            },
            new
            {
                Id = 300304L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 4,
                Title = "آواز گنجشک",
                LessonName = "درس 4: آواز گنجشک",
                CreatedAt
            },
            new
            {
                Id = 300305L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 5,
                Title = "بلدرچین و برزگر",
                LessonName = "درس 5: بلدرچین و برزگر",
                CreatedAt
            },
            new
            {
                Id = 300306L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 6,
                Title = "فداکاران",
                LessonName = "درس 6: فداکاران",
                CreatedAt
            },
            new
            {
                Id = 300307L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 7,
                Title = "کار نیک",
                LessonName = "درس 7: کار نیک",
                CreatedAt
            },
            new
            {
                Id = 300308L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 8,
                Title = "پیراهن بهشتی",
                LessonName = "درس 8: پیراهن بهشتی",
                CreatedAt
            },
            new
            {
                Id = 300309L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 9,
                Title = "بوی نرگس",
                LessonName = "درس 9: بوی نرگس",
                CreatedAt
            },
            new
            {
                Id = 300310L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 10,
                Title = "یار مهربان",
                LessonName = "درس 10: یار مهربان",
                CreatedAt
            },
            new
            {
                Id = 300311L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 11,
                Title = "نویسنده‌ی بزرگ",
                LessonName = "درس 11: نویسنده‌ی بزرگ",
                CreatedAt
            },
            new
            {
                Id = 300312L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 12,
                Title = "ایران عزیز",
                LessonName = "درس 12: ایران عزیز",
                CreatedAt
            },
            new
            {
                Id = 300313L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 13,
                Title = "درس آزاد",
                LessonName = "درس 13: درس آزاد",
                CreatedAt
            },
            new
            {
                Id = 300314L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 14,
                Title = "ایران آباد",
                LessonName = "درس 14: ایران آباد",
                CreatedAt
            },
            new
            {
                Id = 300315L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 15,
                Title = "دریا",
                LessonName = "درس 15: دریا",
                CreatedAt
            },
            new
            {
                Id = 300316L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 16,
                Title = "اگر جنگل نباشد",
                LessonName = "درس 16: اگر جنگل نباشد",
                CreatedAt
            },
            new
            {
                Id = 300317L,
                BookId = SystemBookIds.ThirdGradePersianWriting,
                LessonCount = 17,
                Title = "چشم‌های آسمان",
                LessonName = "درس 17: چشم‌های آسمان",
                CreatedAt
            },
            
            // =====================================================
            // Third Grade - Heavenly Gifts
            // =====================================================
            
            new
            {
                Id = 300501L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 1,
                Title = "آستین‌های خالی",
                LessonName = "درس 1: آستین‌های خالی",
                CreatedAt
            },
            new
            {
                Id = 300502L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 2,
                Title = "غروب یک روز بهاری",
                LessonName = "درس 2: غروب یک روز بهاری",
                CreatedAt
            },
            new
            {
                Id = 300503L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 3,
                Title = "همیشه با من",
                LessonName = "درس 3: همیشه با من",
                CreatedAt
            },
            new
            {
                Id = 300504L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 4,
                Title = "در کاخ نمرود",
                LessonName = "درس 4: در کاخ نمرود",
                CreatedAt
            },
            new
            {
                Id = 300505L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 5,
                Title = "روز دهم",
                LessonName = "درس 5: روز دهم",
                CreatedAt
            },
            new
            {
                Id = 300506L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 6,
                Title = "بانوی مهربان",
                LessonName = "درس 6: بانوی مهربان",
                CreatedAt
            },
            new
            {
                Id = 300507L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 7,
                Title = "بوی بهشت",
                LessonName = "درس 7: بوی بهشت",
                CreatedAt
            },
            new
            {
                Id = 300508L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 8,
                Title = "جشن تکلیف",
                LessonName = "درس 8: جشن تکلیف",
                CreatedAt
            },
            new
            {
                Id = 300509L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 9,
                Title = "گفت‌وگو با خدا",
                LessonName = "درس 9: گفت‌وگو با خدا",
                CreatedAt
            },
            new
            {
                Id = 300510L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 10,
                Title = "ماه مهمانی خدا",
                LessonName = "درس 10: ماه مهمانی خدا",
                CreatedAt
            },
            new
            {
                Id = 300511L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 11,
                Title = "عید مسلمانان",
                LessonName = "درس 11: عید مسلمانان",
                CreatedAt
            },
            new
            {
                Id = 300512L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 12,
                Title = "سخن آسمانی",
                LessonName = "درس 12: سخن آسمانی",
                CreatedAt
            },
            new
            {
                Id = 300513L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 13,
                Title = "انتخاب پروانه",
                LessonName = "درس 13: انتخاب پروانه",
                CreatedAt
            },
            new
            {
                Id = 300514L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 14,
                Title = "اُمّ ابیها",
                LessonName = "درس 14: اُمّ ابیها",
                CreatedAt
            },
            new
            {
                Id = 300515L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 15,
                Title = "هم‌سفر ناشناس",
                LessonName = "درس 15: هم‌سفر ناشناس",
                CreatedAt
            },
            new
            {
                Id = 300516L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 16,
                Title = "داناترین مردم",
                LessonName = "درس 16: داناترین مردم",
                CreatedAt
            },
            new
            {
                Id = 300517L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 17,
                Title = "خواب شیرین",
                LessonName = "درس 17: خواب شیرین",
                CreatedAt
            },
            new
            {
                Id = 300518L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 18,
                Title = "آینه‌ی سخنگو",
                LessonName = "درس 18: آینه‌ی سخنگو",
                CreatedAt
            },
            new
            {
                Id = 300519L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 19,
                Title = "گندم از گندم بروید",
                LessonName = "درس 19: گندم از گندم بروید",
                CreatedAt
            },
            new
            {
                Id = 300520L,
                BookId = SystemBookIds.ThirdGradeHeavenlyGifts,
                LessonCount = 20,
                Title = "باغ همیشه بهار",
                LessonName = "درس 20: باغ همیشه بهار",
                CreatedAt
            },
            
            // =====================================================
            // Third Grade - Social Studies
            // =====================================================
            
            new
            {
                Id = 300601L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 1,
                Title = "من به دنیا آمدم",
                LessonName = "درس 1: من به دنیا آمدم",
                CreatedAt
            },
            new
            {
                Id = 300602L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 2,
                Title = "من بزرگ‌تر شده‌ام",
                LessonName = "درس 2: من بزرگ‌تر شده‌ام",
                CreatedAt
            },
            new
            {
                Id = 300603L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 3,
                Title = "آیا ما مثل هم هستیم؟",
                LessonName = "درس 3: آیا ما مثل هم هستیم؟",
                CreatedAt
            },
            new
            {
                Id = 300604L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 4,
                Title = "اعضای خانواده",
                LessonName = "درس 4: اعضای خانواده",
                CreatedAt
            },
            new
            {
                Id = 300605L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 5,
                Title = "خانواده‌ام را دوست دارم",
                LessonName = "درس 5: خانواده‌ام را دوست دارم",
                CreatedAt
            },
            new
            {
                Id = 300606L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 6,
                Title = "تغییر در خانواده",
                LessonName = "درس 6: تغییر در خانواده",
                CreatedAt
            },
            new
            {
                Id = 300607L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 7,
                Title = "از بزرگترها قدردانی کنیم",
                LessonName = "درس 7: از بزرگترها قدردانی کنیم",
                CreatedAt
            },
            new
            {
                Id = 300608L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 8,
                Title = "چرا با هم همکاری می‌کنیم؟",
                LessonName = "درس 8: چرا با هم همکاری می‌کنیم؟",
                CreatedAt
            },
            new
            {
                Id = 300609L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 9,
                Title = "مقررات خانه‌ی ما",
                LessonName = "درس 9: مقررات خانه‌ی ما",
                CreatedAt
            },
            new
            {
                Id = 300610L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 10,
                Title = "نیازهای خانواده چگونه تأمین می‌شود؟",
                LessonName = "درس 10: نیازهای خانواده چگونه تأمین می‌شود؟",
                CreatedAt
            },
            new
            {
                Id = 300611L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 11,
                Title = "منابع",
                LessonName = "درس 11: منابع",
                CreatedAt
            },
            new
            {
                Id = 300612L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 12,
                Title = "درست مصرف کنیم",
                LessonName = "درس 12: درست مصرف کنیم",
                CreatedAt
            },
            new
            {
                Id = 300613L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 13,
                Title = "بازیافت",
                LessonName = "درس 13: بازیافت",
                CreatedAt
            },
            new
            {
                Id = 300614L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 14,
                Title = "خانه‌ام را دوست دارم",
                LessonName = "درس 14: خانه‌ام را دوست دارم",
                CreatedAt
            },
            new
            {
                Id = 300615L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 15,
                Title = "خانه‌ها با هم تفاوت دارند",
                LessonName = "درس 15: خانه‌ها با هم تفاوت دارند",
                CreatedAt
            },
            new
            {
                Id = 300616L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 16,
                Title = "خانه‌ی شما چه شکلی است؟",
                LessonName = "درس 16: خانه‌ی شما چه شکلی است؟",
                CreatedAt
            },
            new
            {
                Id = 300617L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 17,
                Title = "از خانه محافظت کنیم",
                LessonName = "درس 17: از خانه محافظت کنیم",
                CreatedAt
            },
            new
            {
                Id = 300618L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 18,
                Title = "مدرسه‌ی دوست‌داشتنی ما",
                LessonName = "درس 18: مدرسه‌ی دوست‌داشتنی ما",
                CreatedAt
            },
            new
            {
                Id = 300619L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 19,
                Title = "مکان‌های مدرسه را بشناسیم",
                LessonName = "درس 19: مکان‌های مدرسه را بشناسیم",
                CreatedAt
            },
            new
            {
                Id = 300620L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 20,
                Title = "خانه‌ی شما کجاست؟",
                LessonName = "درس 20: خانه‌ی شما کجاست؟",
                CreatedAt
            },
            new
            {
                Id = 300621L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 21,
                Title = "جهت‌های اصلی",
                LessonName = "درس 21: جهت‌های اصلی",
                CreatedAt
            },
            new
            {
                Id = 300622L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 22,
                Title = "پست",
                LessonName = "درس 22: پست",
                CreatedAt
            },
            new
            {
                Id = 300623L,
                BookId = SystemBookIds.ThirdGradeSocialStudies,
                LessonCount = 23,
                Title = "ایمنی در کوچه و خیابان",
                LessonName = "درس 23: ایمنی در کوچه و خیابان",
                CreatedAt
            }
        );
    }
}
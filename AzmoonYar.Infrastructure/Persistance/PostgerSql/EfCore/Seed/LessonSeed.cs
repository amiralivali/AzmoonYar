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
            }
        );
}}
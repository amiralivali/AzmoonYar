using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Seed;

public class BookSeed
{
    private static readonly DateTimeOffset CreatedAt =
        new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static void Seed(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Book>().HasData(

            // ==========================================
            // First Grade
            // ==========================================

            new
            {
                Id = SystemBookIds.FirstGradeMath,
                BookName = "ریاضی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/first-grade-math.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.FirstGradeScience,
                BookName = "علوم تجربی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/first-grade-science.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.FirstGradePersian,
                BookName = "فارسی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/first-grade-persian.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.FirstGradePersianWriting,
                BookName = "نگارش فارسی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/first-grade-persian-writing.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.FirstGradeQuran,
                BookName = "آموزش قرآن اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/first-grade-quran.jpg",
                CreatedAt
            },

            // ==========================================
            // Second Grade
            // ==========================================

            new
            {
                Id = SystemBookIds.SecondGradeMath,
                BookName = "ریاضی دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-math.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.SecondGradeScience,
                BookName = "علوم تجربی دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-science.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.SecondGradePersian,
                BookName = "فارسی دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-persian.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.SecondGradePersianWriting,
                BookName = "نگارش فارسی دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-persian-writing.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.SecondGradeQuran,
                BookName = "آموزش قرآن دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-quran.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.SecondGradeHeavenlyGifts,
                BookName = "هدیه‌های آسمان دوم ابتدایی",
                Grade = Grade.ElementarySecond,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/second-grade-heavenly-gifts.jpg",
                CreatedAt
            },
            
            // =========================
// Third Grade
// =========================

            new
            {
                Id = SystemBookIds.ThirdGradeMath,
                BookName = "ریاضی سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-math.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.ThirdGradeScience,
                BookName = "علوم تجربی سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-science.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.ThirdGradePersian,
                BookName = "فارسی سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-persian.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.ThirdGradePersianWriting,
                BookName = "نگارش فارسی سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-persian-writing.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.ThirdGradeHeavenlyGifts,
                BookName = "هدیه‌های آسمان سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-heavenly-gifts.jpg",
                CreatedAt
            },

            new
            {
                Id = SystemBookIds.ThirdGradeSocialStudies,
                BookName = "مطالعات اجتماعی سوم ابتدایی",
                Grade = Grade.ElementaryThird,
                BookSource = BookSource.System,
                Picture = "/Uploads/Books/third-grade-social-studies.jpg",
                CreatedAt
            }
        );
    }
}
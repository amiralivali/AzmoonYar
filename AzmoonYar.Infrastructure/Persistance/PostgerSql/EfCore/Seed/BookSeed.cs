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
            new
            {
                Id = SystemBookIds.FirstGradeMath,
                BookName = "ریاضی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                CreatedAt
            },
            new
            {
                Id = SystemBookIds.FirstGradeScience,
                BookName = "علوم تجربی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                CreatedAt
            },
            new
            {
                Id = SystemBookIds.FirstGradePersian,
                BookName = "فارسی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                CreatedAt
            },
            new
            {
                Id = SystemBookIds.FirstGradePersianWriting,
                BookName = "نگارش فارسی اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                CreatedAt
            },
            new
            {
                Id = SystemBookIds.FirstGradeQuran,
                BookName = "آموزش قرآن اول ابتدایی",
                Grade = Grade.ElementaryFirst,
                BookSource = BookSource.System,
                CreatedAt
            }
        );
    }
}
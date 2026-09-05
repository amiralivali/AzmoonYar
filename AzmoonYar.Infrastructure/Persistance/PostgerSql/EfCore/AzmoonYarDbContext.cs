using System.Reflection;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;

public class AzmoonYarDbContext(DbContextOptions<AzmoonYarDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<OptionalItem> OptionalItems { get; set; }
    public DbSet<TrueFalseItem> TrueFalseItems { get; set; }
    public DbSet<MatchingItem> MatchingItems { get; set; }
    public DbSet<FillInBlankItem> FillInBlankItems { get; set; }
    public DbSet<FillInBlankAnswer> FillInBlankAnswers { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<ExamQuestionType> ExamQuestionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        BookSeed.Seed(modelBuilder);
        LessonSeed.Seed(modelBuilder);
    }
}
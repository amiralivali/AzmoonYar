using System.Reflection;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;

public class AzmoonYarDbContext(DbContextOptions<AzmoonYarDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BaseQuestion> Questions { get; set; }
    public DbSet<OptionalItem> OptionalItems { get; set; }
    public DbSet<TrueFalseItem> TrueFalseItems { get; set; }
    public DbSet<MatchingItem> MatchingItems { get; set; }
    public DbSet<FillInBlankItem> FillInBlankItems { get; set; }
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
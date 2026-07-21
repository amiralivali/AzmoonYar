using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class LessonConfiguration:IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LessonName)
            .IsRequired()
            .HasMaxLength(LessonConstants.LessonNameMaxLenght);
        builder.Property(x => x.Title)
            .IsRequired(false)
            .HasMaxLength(LessonConstants.LessonNameMaxLenght);
        builder.HasOne(x => x.Book)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => new { x.BookId, x.LessonName });
    }
}
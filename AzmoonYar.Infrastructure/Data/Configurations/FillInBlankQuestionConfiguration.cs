using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class FillInBlankQuestionConfiguration : IEntityTypeConfiguration<FillInBlankQuestion>
{
    public void Configure(EntityTypeBuilder<FillInBlankQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QuestionText)
            .IsRequired(true)
            .HasMaxLength(200);
        builder.Property(x => x.Picture)
            .IsRequired(false)
            .HasMaxLength(1000);
        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.FillInBlankQuestions)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => x.QuestionText);
    }
}
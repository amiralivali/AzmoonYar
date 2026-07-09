using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class MatchingQuestionConfiguration: IEntityTypeConfiguration<MatchingQuestion>
{
    public void Configure(EntityTypeBuilder<MatchingQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QuestionText)
            .IsRequired(true)
            .HasMaxLength(200);
        builder.Property(x => x.Picture)
            .IsRequired(false)
            .HasMaxLength(1000);
        builder.HasOne(q => q.Lesson)
            .WithMany(l => l.MatchingQuestions)
            .HasForeignKey(q => q.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => x.QuestionText);
    }
}
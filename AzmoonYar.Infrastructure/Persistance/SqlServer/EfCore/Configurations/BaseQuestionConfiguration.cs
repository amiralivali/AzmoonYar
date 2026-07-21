using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Configurations;

public class BaseQuestionConfiguration : IEntityTypeConfiguration<BaseQuestion>
{
    public void Configure(EntityTypeBuilder<BaseQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QuestionText)
            .IsRequired()
            .HasMaxLength(BaseQuestionConstants.QuestionTextMaxLength);
        builder.Property(x => x.Picture)
            .HasMaxLength(BaseQuestionConstants.PictureMaxLenght);
        builder.Property(x => x.DifficultyLevel)
            .IsRequired();
        builder.HasOne(x => x.Lesson)
            .WithMany()
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
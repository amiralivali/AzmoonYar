using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class ExamQuestionTypeConfiguration : IEntityTypeConfiguration<ExamQuestionType>
{
    public void Configure(EntityTypeBuilder<ExamQuestionType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<Exam>()
            .WithMany(x => x.ExamQuestionTypes)
            .HasForeignKey(x => x.ExamId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.QuestionType)
            .IsRequired();
        builder.Property(x => x.Count)
            .IsRequired();
    }
}
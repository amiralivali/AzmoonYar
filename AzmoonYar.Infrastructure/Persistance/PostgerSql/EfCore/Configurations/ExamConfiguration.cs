using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.DifficultyLevel)
            .IsRequired();
        builder.Property(x => x.ExamType)
            .IsRequired();
        builder.OwnsOne(x => x.Header, header =>
        {
            header.Property(h => h.SchoolName).HasMaxLength(ExamConstants.SchoolNameMaxLength);
            header.Property(h => h.ExamTitle).HasMaxLength(ExamConstants.ExamTitleMaxLength);
            header.Property(h => h.TeacherName).HasMaxLength(ExamConstants.TeacherNameMaxLength);
            header.Property(h => h.ClassName).HasMaxLength(ExamConstants.ClassNameMaxLength);
            header.Property(h => h.ExamDate);
            header.Property(h => h.DurationMinutes);
            header.Property(h => h.LogoPicture).HasMaxLength(ExamConstants.LogoPictureMaxLength);
            header.Property(h => h.HeaderPicture).HasMaxLength(ExamConstants.HeaderPictureMaxLength);
        });
        builder.HasMany(x => x.Lessons)
            .WithMany();
    }
}
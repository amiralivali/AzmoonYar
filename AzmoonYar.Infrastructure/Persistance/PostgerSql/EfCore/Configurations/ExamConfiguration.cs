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
        builder.OwnsOne(p => p.Header, header =>
        {
            header.Property(h => h.HeaderPicture)
                .HasColumnName(ExamConstants.HeaderPicture)
                .HasMaxLength(ExamConstants.HeaderPictureMaxLength);

            header.Property(h => h.LogoPicture)
                .HasColumnName(ExamConstants.LogoPicture)
                .HasMaxLength(ExamConstants.LogoPictureMaxLength);

            header.Property(h => h.HeaderText)
                .HasColumnName(ExamConstants.HeaderText)
                .HasMaxLength(ExamConstants.HeaderTextMaxLength);
        });
        builder.HasMany(x => x.Lessons)
            .WithMany();
    }
}
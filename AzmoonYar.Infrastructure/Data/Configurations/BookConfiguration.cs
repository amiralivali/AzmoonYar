using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BookName)
            .IsRequired(true)
            .HasMaxLength(50);
        builder.Property(x => x.GradeInfo)
            .IsRequired(false)
            .HasMaxLength(80);
        builder.HasIndex(x => x.BookName);
    }
}
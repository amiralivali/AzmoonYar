using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BookName)
            .IsRequired(true)
            .HasMaxLength(BookConstants.BookNameMaxLength);
        builder.Property(x => x.GradeInfo)
            .IsRequired(false)
            .HasMaxLength(BookConstants.GradeInfoMaxLenght);
        builder.HasIndex(x => x.BookName);
    }
}
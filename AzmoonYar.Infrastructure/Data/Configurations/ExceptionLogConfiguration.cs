using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
{
    public void Configure(EntityTypeBuilder<ExceptionLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(x => x.StackTrace)
            .HasMaxLength(16000);

        builder.Property(x => x.ExceptionType)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Source)
            .HasMaxLength(200);

        builder.Property(x => x.InnerException)
            .HasMaxLength(4000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasIndex(x => x.CreatedAt);

        builder.HasIndex(x => x.ExceptionType);
    }
}
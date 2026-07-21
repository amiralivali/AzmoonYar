using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
{
    public void Configure(EntityTypeBuilder<ExceptionLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(ExceptionLogConfigurationConstants.MessageMaxLength);

        builder.Property(x => x.StackTrace)
            .HasMaxLength(ExceptionLogConfigurationConstants.StackTraceMaxLenght);

        builder.Property(x => x.ExceptionType)
            .IsRequired()
            .HasMaxLength(ExceptionLogConfigurationConstants.ExceptionTypeMaxLength);

        builder.Property(x => x.Source)
            .HasMaxLength(ExceptionLogConfigurationConstants.SourceMaxLength);

        builder.Property(x => x.InnerException)
            .HasMaxLength(ExceptionLogConfigurationConstants.InnerExceptionMaxLength);

        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasIndex(x => x.CreatedAt);

        builder.HasIndex(x => x.ExceptionType);
    }
}
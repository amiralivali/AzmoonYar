using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.FirstName)
            .HasMaxLength(30)
            .IsRequired();
        builder.Property(x=>x.LastName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x=>x.UserName)
            .HasMaxLength(50)
            .IsRequired(false);  
        builder.Property(x=>x.Password)
            .HasMaxLength(50)
            .IsRequired(false);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsRequired();
    }
}
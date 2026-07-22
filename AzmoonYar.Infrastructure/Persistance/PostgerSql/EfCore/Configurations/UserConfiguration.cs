using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.FirstName)
            .HasMaxLength(UserConstants.FirstNameMaxLength)
            .IsRequired();
        builder.Property(x=>x.LastName)
            .HasMaxLength(UserConstants.LastNameMaxLength)
            .IsRequired();
        builder.Property(x=>x.UserName)
            .HasMaxLength(UserConstants.UsernameMaxLength)
            .IsRequired(false);  
        builder.Property(x=>x.Password)
            .HasMaxLength(UserConstants.PasswordMaxLength)   
            .IsRequired(false);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(UserConstants.PhoneNumberMaxLength)
            .IsUnicode(false)
            .IsRequired();
    }
}
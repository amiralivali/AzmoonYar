using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Configurations;

public class OptionalItemConfiguration:IEntityTypeConfiguration<OptionalItem>
{
    public void Configure(EntityTypeBuilder<OptionalItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Option1)
            .IsRequired(true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.Property(x => x.Option2)
            .IsRequired(true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.Property(x => x.Option3)
            .IsRequired(true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.Property(x => x.Option4)
            .IsRequired(true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.HasOne(x => x.OptionalQuestion)
            .WithOne(x => x.OptionalItem)
            .HasForeignKey<OptionalItem>(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Configurations;

public class MatchingItemConfiguration : IEntityTypeConfiguration<MatchingItem>
{
    public void Configure(EntityTypeBuilder<MatchingItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LeftItemText)
            .IsRequired()
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);

        builder.Property(x => x.RightItemText)
            .IsRequired()
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);

        builder.HasOne(x => x.MatchingQuestion)
            .WithMany(x => x.MatchingItems)
            .HasForeignKey(x => x.MatchingQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class MatchingItemConfiguration:IEntityTypeConfiguration<MatchingItem>
{
    public void Configure(EntityTypeBuilder<MatchingItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LeftItemText)
            .IsRequired(true)
            .HasMaxLength(200);
        builder.Property(x => x.RightItemText)
            .IsRequired(true)
            .HasMaxLength(200);
        builder.HasOne(x => x.MatchingQuestion)
            .WithMany(x => x.MatchingItems)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
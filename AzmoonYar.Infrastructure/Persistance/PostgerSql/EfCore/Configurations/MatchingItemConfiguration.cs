using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class MatchingItemConfiguration : IEntityTypeConfiguration<MatchingItem>
{
    public void Configure(EntityTypeBuilder<MatchingItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LeftItemText)
            .IsRequired()
            .HasMaxLength(MatchingItemConstants.LeftItemTextMaxLength);

        builder.Property(x => x.RightItemText)
            .IsRequired()
            .HasMaxLength(MatchingItemConstants.RightItemTextMaxLength);

        builder.HasOne<Question>()            .WithMany(x => x.MatchingItems)
            .HasForeignKey(x => x.MatchingQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
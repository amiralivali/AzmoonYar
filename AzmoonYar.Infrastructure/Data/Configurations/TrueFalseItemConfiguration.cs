using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class TrueFalseItemConfiguration:IEntityTypeConfiguration<TrueFalseItem>
{
    public void Configure(EntityTypeBuilder<TrueFalseItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ItemText)
            .IsRequired(true)
            .HasMaxLength(200);
        builder.HasOne(x => x.TrueFalseQuestion)
            .WithMany(x => x.TrueFalseItems)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
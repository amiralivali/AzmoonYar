using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class TrueFalseItemConfiguration:IEntityTypeConfiguration<TrueFalseItem>
{
    public void Configure(EntityTypeBuilder<TrueFalseItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ItemText)
            .IsRequired(true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.HasOne<BaseQuestion>()           
            .WithMany(x => x.TrueFalseItems)
            .HasForeignKey(x => x.TrueFalseQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
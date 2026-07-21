using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class FillInBlankItemConfiguration:IEntityTypeConfiguration<FillInBlankItem>
{
    public void Configure(EntityTypeBuilder<FillInBlankItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ItemText)
            .IsRequired (true)
            .HasMaxLength(BaseItemConstants.ItemTextMaxLength);
        builder.HasOne<BaseQuestion>()
            .WithMany(x => x.FillInBlankItems)
            .HasForeignKey(x => x.FillInBlankQuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
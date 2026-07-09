using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Data.Configurations;

public class FillInBlankItemConfiguration:IEntityTypeConfiguration<FillInBlankItem>
{
    public void Configure(EntityTypeBuilder<FillInBlankItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ItemText)
            .IsRequired (true)
            .HasMaxLength(200);
        builder.HasOne(x => x.FillInBlankQuestion)
            .WithMany(x => x.FillInBlankItems)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
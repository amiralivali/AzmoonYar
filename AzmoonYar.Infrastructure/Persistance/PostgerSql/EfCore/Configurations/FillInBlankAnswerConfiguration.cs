using AzmoonYar.Domain.Constants;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Configurations;

public class FillInBlankAnswerConfiguration : IEntityTypeConfiguration<FillInBlankAnswer>
{
    public void Configure(EntityTypeBuilder<FillInBlankAnswer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Answer)
            .IsRequired()
            .HasMaxLength(FillInBlankAnswerConstants.MaxAnswerLength);
        builder.HasOne<FillInBlankItem>()
            .WithMany(x=>x.Answers)
            .HasForeignKey(x=>x.FillInBlankItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
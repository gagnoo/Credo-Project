using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations.Bill;

public class BillTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.BillingEntity.Bill>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.BillingEntity.Bill> builder)
    {
        builder.ToTable(TableNames.BillingTable);

        builder.HasKey(i => i.BillId);

        builder.Property(i => i.Amount)
               .HasColumnType(DbTypes.Money)
               .IsRequired();

        builder.Property(i => i.NumberOfParticipants)
               .HasColumnType(DbTypes.Int)
               .IsRequired();

        builder.Property(i => i.IsPayed)
               .HasColumnType(DbTypes.Boolean)
               .IsRequired();
    }
}
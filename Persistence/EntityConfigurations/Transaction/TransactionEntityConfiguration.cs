using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations.Transaction;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.TransactionEntity.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.TransactionEntity.Transaction> builder)
    {
        builder.ToTable(TableNames.TransactionTable);

        builder.HasKey(i => i.TransactionId);

        builder.Property(i => i.Amount)
               .HasColumnType(DbTypes.Money)
               .IsRequired();

        builder.Property(i => i.AmountPerPerson)
               .HasColumnType(DbTypes.Money)
               .IsRequired();

        builder.Property(i => i.IsPayed)
               .HasColumnType(DbTypes.Boolean)
               .IsRequired();

        builder.HasOne(i => i.DebtorUser)
               .WithMany(i => i.Debtors)
               .HasForeignKey(i => i.DebtorId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.CreditorUser)
               .WithMany(i => i.Creditors)
               .HasForeignKey(i => i.CreditorId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Bill)
               .WithMany(i => i.BillTransactions)
               .HasForeignKey(i => i.BillId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
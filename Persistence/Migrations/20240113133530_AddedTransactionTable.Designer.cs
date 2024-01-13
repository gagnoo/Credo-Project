﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CredoDbContext))]
    [Migration("20240113133530_AddedTransactionTable")]
    partial class AddedTransactionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.BillingEntity.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<bool>("IsPayed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int>("NumberOfParticipants")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TransactionEntity.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountPerPerson")
                        .HasColumnType("money");

                    b.Property<int>("CreditorId")
                        .HasColumnType("int");

                    b.Property<int>("DebtorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.HasKey("TransactionId");

                    b.HasIndex("CreditorId");

                    b.HasIndex("DebtorId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserEntity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TransactionEntity.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity.User", "CreditorUser")
                        .WithMany("Creditors")
                        .HasForeignKey("CreditorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity.User", "DebtorUser")
                        .WithMany("Debtors")
                        .HasForeignKey("DebtorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreditorUser");

                    b.Navigation("DebtorUser");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity.User", b =>
                {
                    b.Navigation("Creditors");

                    b.Navigation("Debtors");
                });
#pragma warning restore 612, 618
        }
    }
}
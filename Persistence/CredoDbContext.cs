using System.Reflection;
using Domain.Entities.BillingEntity;
using Domain.Entities.TransactionEntity;
using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class CredoDbContext : DbContext
{
    public CredoDbContext(DbContextOptions<CredoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
using Domain.Entities.BillingEntity;
using Domain.Entities.TransactionEntity;

namespace Domain.Entities.UserEntity;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }

    public ICollection<Transaction> Debtors { get; set; }
    public ICollection<Transaction> Creditors { get; set; }
}
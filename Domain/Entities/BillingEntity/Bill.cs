using Domain.Entities.TransactionEntity;
using Domain.Entities.UserEntity;

namespace Domain.Entities.BillingEntity;

public class Bill
{
    public int BillId { get; set; }
    public decimal Amount { get; set; }
    public int NumberOfParticipants { get; set; }
    public bool IsPayed { get; set; }

    public ICollection<Transaction> BillTransactions { get; set; }
}
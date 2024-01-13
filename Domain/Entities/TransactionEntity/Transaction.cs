using Domain.Entities.BillingEntity;
using Domain.Entities.UserEntity;

namespace Domain.Entities.TransactionEntity;

public class Transaction
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountPerPerson { get; set; }
    public bool IsPayed { get; set; }

    public int DebtorId { get; set; }
    public User DebtorUser { get; set; }

    public int CreditorId { get; set; }
    public User CreditorUser { get; set; }

    public int BillId { get; set; }
    public Bill Bill { get; set; }
}
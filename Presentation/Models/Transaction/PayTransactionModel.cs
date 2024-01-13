namespace Presentation.Models.Transaction;

public class PayTransactionModel
{
    public int TransactionId { get; set; }
    public int BillId { get; set; }
    public int CreditorUserId { get; set; }
    public decimal Amount { get; set; }
}
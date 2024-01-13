namespace Presentation.Models.Transaction;

public class CreateTransactionModel
{
    public decimal Amount { get; set; }
    public int DebtorId { get; set; }
    public IEnumerable<int> CreditorIds { get; set; }
    public int BillId { get; set; }
}
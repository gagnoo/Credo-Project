namespace Presentation.Models.Bill;

public class CreateBillModel
{
    public decimal Amount { get; set; }
    public int DebitorId { get; set; }
    public IEnumerable<int> ParticipantIds { get; set; }
}
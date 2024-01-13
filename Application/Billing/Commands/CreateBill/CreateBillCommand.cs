using MediatR;

namespace Application.Billing.Commands.CreateBill;

public record CreateBillCommand(decimal Amount, IEnumerable<int> ParticipantIds, int DebitorId) : IRequest<int>;
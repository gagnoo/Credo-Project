using MediatR;

namespace Application.Billing.Commands.UpdateBillStatus;

public record UpdateBillStatusCommand(int BillId) : IRequest<bool>;
using Domain.Entities.BillingEntity;
using MediatR;

namespace Application.Billing.Commands.GetBill;

public record GetBillCommand(int BillId) : IRequest<Bill?>;
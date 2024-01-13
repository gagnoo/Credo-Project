using Domain.Abstractions;
using Domain.Entities.BillingEntity;
using MediatR;

namespace Application.Billing.Commands.GetBill;

public class GetBillHandler : IRequestHandler<GetBillCommand, Bill?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBillHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Bill?> Handle(GetBillCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BillingRepository.GetAsync(i => i.BillId == request.BillId, cancellationToken);
    }
}
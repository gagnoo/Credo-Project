using Application.Billing.Commands.GetBill;
using Domain.Abstractions;
using Domain.Entities.BillingEntity;
using MediatR;

namespace Application.Billing.Commands.UpdateBillStatus;

public class UpdateBillStatusHandler : IRequestHandler<UpdateBillStatusCommand, bool>
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBillStatusHandler(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBillStatusCommand request, CancellationToken cancellationToken)
    {
        Bill? bill = await _mediator.Send(new GetBillCommand(request.BillId), cancellationToken);
        if (bill is null)
        {
            return false;
        }

        bill.IsPayed = true;
        return await _unitOfWork.SaveAsync(cancellationToken) > 0;
    }
}
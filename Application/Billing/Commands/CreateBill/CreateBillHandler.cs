using Application.Transaction.Commands.CreateTransaction;
using Domain.Abstractions;
using Domain.Entities.BillingEntity;
using MediatR;

namespace Application.Billing.Commands.CreateBill;

public class CreateBillHandler : IRequestHandler<CreateBillCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateBillHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateBillCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Bill bill = new()
            {
                Amount = request.Amount,
                NumberOfParticipants = request.ParticipantIds.Count(),
                IsPayed = false
            };
            _unitOfWork.BillingRepository.Add(bill);
            await _unitOfWork.SaveAsync(cancellationToken);

            CreateTransactionCommand command = new(request.Amount, request.ParticipantIds, request.DebitorId, bill.BillId);
            int createTransactionResult = await _mediator.Send(command, cancellationToken);

            return await _unitOfWork.SaveAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            throw;
        }
    }
}
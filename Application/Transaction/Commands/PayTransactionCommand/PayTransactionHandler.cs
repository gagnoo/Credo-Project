using Application.Billing.Commands.UpdateBillStatus;
using Application.Transaction.Queries.GetTransactionsByBillId;
using Domain.Abstractions;
using MediatR;

namespace Application.Transaction.Commands.PayTransactionCommand;

public class PayTransactionHandler : IRequestHandler<PayTransactionCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public PayTransactionHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<bool> Handle(PayTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.TransactionEntity.Transaction? transaction = await _unitOfWork
                                                                               .TransactionRepository
                                                                               .GetAsync(i => i.BillId == request.BillId &&
                                                                                              i.CreditorId == request.CreditorUserId &&
                                                                                              i.TransactionId == request.TransactionId,
                                                                                         cancellationToken);
            if (transaction is null)
            {
                return false;
            }

            if (request.Amount < transaction.AmountPerPerson)
            {
                return false;
            }

            transaction.IsPayed = true;
            _unitOfWork.TransactionRepository.Update(transaction);
            int result = await _unitOfWork.SaveAsync(cancellationToken);

            List<Domain.Entities.TransactionEntity.Transaction> currentTransactions =
                await _mediator.Send(new GetTransactionByBillIdCommand(request.BillId), cancellationToken);

            if (currentTransactions.TrueForAll(i => i.IsPayed))
            {
                await _mediator.Send(new UpdateBillStatusCommand(request.BillId), cancellationToken);
            }

            return result > 0;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            throw;
        }
    }
}
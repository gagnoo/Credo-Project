using Application.Billing.Commands.GetBill;
using Application.User.Commands.GetUser;
using Application.User.Queries.GetAllUsers.Models;
using Domain.Abstractions;
using Domain.Entities.BillingEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateTransactionHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Bill? bill = await _mediator.Send(new GetBillCommand(request.BillId), cancellationToken);
            UserResponseModel? debtorUser = await _mediator.Send(new GetUserCommand(request.DebtorId), cancellationToken);

            List<Domain.Entities.UserEntity.User> creditorUsers = await _unitOfWork
                                                                        .UserRepository
                                                                        .List(i => request.CreditorIds.Contains(i.UserId))
                                                                        .ToListAsync(cancellationToken: cancellationToken);

            if (bill is null || debtorUser is null || !creditorUsers.Any())
            {
                return -1;
            }

            decimal amountPerPerson = request.Amount / creditorUsers.Count;

            foreach (Domain.Entities.UserEntity.User creditor in creditorUsers)
            {
                Domain.Entities.TransactionEntity.Transaction transaction = new()
                {
                    Amount = request.Amount,
                    AmountPerPerson = amountPerPerson,
                    CreditorId = creditor.UserId,
                    BillId = bill.BillId,
                    DebtorId = debtorUser.UserId,
                    IsPayed = false
                };

                _unitOfWork.TransactionRepository.Add(transaction);
            }

            int result = await _unitOfWork.SaveAsync(cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            throw;
        }
    }
}
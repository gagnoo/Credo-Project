using MediatR;

namespace Application.Transaction.Commands.CreateTransaction;

public record CreateTransactionCommand(
    decimal Amount,
    IEnumerable<int> CreditorIds,
    int DebtorId,
    int BillId
) : IRequest<int>;
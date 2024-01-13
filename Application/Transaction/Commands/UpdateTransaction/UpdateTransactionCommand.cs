using MediatR;

namespace Application.Transaction.Commands.UpdateTransaction;

public record UpdateTransactionCommand(int TransactionId, int BillId, int CreditorUserId) : IRequest<bool>;
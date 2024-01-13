using MediatR;

namespace Application.Transaction.Commands.PayTransactionCommand;

public record PayTransactionCommand(int TransactionId, int BillId, int CreditorUserId, decimal Amount) : IRequest<bool>;
using MediatR;

namespace Application.Transaction.Queries.GetTransactionsByBillId;

public record GetTransactionByBillIdCommand(int BillId) : IRequest<List<Domain.Entities.TransactionEntity.Transaction>>;
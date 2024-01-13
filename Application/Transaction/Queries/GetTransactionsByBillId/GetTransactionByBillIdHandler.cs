using Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Transaction.Queries.GetTransactionsByBillId;

public class GetTransactionByBillIdHandler : IRequestHandler<GetTransactionByBillIdCommand,
    List<Domain.Entities.TransactionEntity.Transaction>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransactionByBillIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Domain.Entities.TransactionEntity.Transaction>> Handle(GetTransactionByBillIdCommand request,
                                                                                  CancellationToken cancellationToken)
    {
        return await _unitOfWork.TransactionRepository.List(i => i.BillId == request.BillId).ToListAsync(cancellationToken);
    }
}
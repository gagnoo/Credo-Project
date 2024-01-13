using Domain.Abstractions.Repositories;
using Domain.Entities.TransactionEntity;

namespace Persistence.Abstractions.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CredoDbContext context) : base(context)
    {
    }
}
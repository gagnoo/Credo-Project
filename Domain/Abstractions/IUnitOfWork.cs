using Domain.Abstractions.Repositories;

namespace Domain.Abstractions;

public interface IUnitOfWork
{
    int Save();
    Task<int> SaveAsync(CancellationToken cancellationToken = default);

    IUserRepository UserRepository { get; }
    IBillingRepository BillingRepository { get; }
    ITransactionRepository TransactionRepository { get; }
}
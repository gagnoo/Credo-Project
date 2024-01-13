using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Persistence.Abstractions.Repositories;

namespace Persistence.Abstractions.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CredoDbContext _context;

    #region Private Fields

    private IUserRepository _userRepository;
    private IBillingRepository _billingRepository;
    private ITransactionRepository _transactionRepository;

    #endregion

    public UnitOfWork(CredoDbContext context)
    {
        _context = context;
    }

    #region Public Properties

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IBillingRepository BillingRepository => _billingRepository ??= new BillingRepository(_context);

    public ITransactionRepository TransactionRepository => _transactionRepository ??= new TransactionRepository(_context);

    #endregion

    public int Save()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
using Domain.Abstractions.Repositories;
using Domain.Entities.BillingEntity;

namespace Persistence.Abstractions.Repositories;

public class BillingRepository : BaseRepository<Bill>, IBillingRepository
{
    public BillingRepository(CredoDbContext context) : base(context)
    {
    }
}
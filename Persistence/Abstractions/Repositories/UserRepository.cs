using Domain.Abstractions.Repositories;
using Domain.Entities.UserEntity;

namespace Persistence.Abstractions.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(CredoDbContext context) : base(context)
    {
    }
}
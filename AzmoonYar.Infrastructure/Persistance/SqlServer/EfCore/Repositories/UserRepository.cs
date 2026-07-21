using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public class UserRepository(AzmoonYarDbContext context) : RepositoryBase<User>(context), IUserRepository
{
}
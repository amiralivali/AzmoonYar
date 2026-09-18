using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class RefreshTokenRepository(AzmoonYarDbContext context) : RepositoryBase<RefreshToken>(context), IRefreshTokenRepository
{
    
}
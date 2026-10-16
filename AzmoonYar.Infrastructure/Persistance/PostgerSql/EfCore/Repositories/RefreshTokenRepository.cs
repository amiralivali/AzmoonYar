using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class RefreshTokenRepository(AzmoonYarDbContext context) : RepositoryBase<RefreshToken>(context), IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByHashWithUserAsync(string tokenHash, CancellationToken cancellationToken = default)
    {
        return await Context.RefreshTokens.Include(x => x.User)
            .Where(x => x.TokenHash == tokenHash).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<IReadOnlyList<RefreshToken>> GetActiveByFamilyAsync(string family,
        CancellationToken cancellationToken = default)
        => await Context.RefreshTokens
            .Where(token => token.Family == family && token.RevokedAt == null &&
                            token.ExpiresAt > DateTimeOffset.UtcNow)
            .ToListAsync(cancellationToken);
}
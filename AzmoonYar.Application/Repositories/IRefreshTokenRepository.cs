using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Repositories;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetByHashWithUserAsync(string tokenHash,
        CancellationToken cancellationToken = default);
}
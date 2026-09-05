using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> CheckPhoneNumberDuplicate(string phoneNumber, CancellationToken cancellationToken,long userId = 0);
    Task<bool> CheckEmailDuplicate(string email, CancellationToken cancellationToken,long userId = 0);
    Task<User?> GetByPhoneNumberAsync(string mobileNumber, CancellationToken cancellationToken);
    
}
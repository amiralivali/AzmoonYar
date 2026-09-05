using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class UserRepository(AzmoonYarDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<bool> CheckPhoneNumberDuplicate(string phoneNumber, CancellationToken cancellationToken ,long userId = 0)
    {
        if (userId == 0)
        {
            return await Context.Users.Where(x=>x.PhoneNumber == phoneNumber).AnyAsync(cancellationToken);
        }
        else
        {
            return await Context.Users.Where(x=>x.Id != userId && x.PhoneNumber == phoneNumber).AnyAsync(cancellationToken);
        }
    }

    public async Task<bool> CheckEmailDuplicate(string email, CancellationToken cancellationToken, long userId = 0)
    {
        if (userId == 0)
        {
            return await Context.Users.Where(x=>x.Email == email).AnyAsync(cancellationToken);
        }
        else
        {
            return await Context.Users.Where(x=>x.Id != userId && x.Email == email).AnyAsync(cancellationToken);
        }    }

    public async Task<User?> GetByPhoneNumberAsync(string mobileNumber, CancellationToken cancellationToken)
    {
        return await Context.Users.Where(x => x.PhoneNumber == mobileNumber).SingleOrDefaultAsync(cancellationToken);
    }
}
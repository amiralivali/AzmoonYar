using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

public class ExceptionLogRepository(AzmoonYarDbContext context) : RepositoryBase<ExceptionLog>(context) , IExceptionLogRepository
{
    
}
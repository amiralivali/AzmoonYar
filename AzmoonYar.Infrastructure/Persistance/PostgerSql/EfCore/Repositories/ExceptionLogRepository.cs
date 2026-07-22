using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Infrastructure.Persistance.SqlServer.EfCore.Repositories;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;

public class ExceptionLogRepository(AzmoonYarDbContext context) : RepositoryBase<ExceptionLog>(context) , IExceptionLogRepository
{
    
}
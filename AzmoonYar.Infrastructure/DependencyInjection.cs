using AzmoonYar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzmoonYar.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection builder,IConfiguration configuration)
    {
        builder.AddDbContext<AzmoonYarDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
    }
}
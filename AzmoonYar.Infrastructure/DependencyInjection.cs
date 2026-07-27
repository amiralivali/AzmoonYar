using AzmoonYar.Application.Repositories;
using AzmoonYar.Infrastructure.Persistance.Mongo;
using AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzmoonYar.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection builder,IConfiguration configuration)
    {
        builder.AddDbContext<AzmoonYarDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgerSql")));
        builder.AddScoped<IBookRepository, BookRepository>();
        builder.AddScoped<IQuestionRepository, QuestionRepository>();
        builder.AddScoped<IUserRepository, UserRepository>();
        
        builder.AddMongo(configuration);
    }
    private static void AddMongo(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoSettings>(configuration.GetSection(MongoSettings.SectionName));
        MongoMappingConfig.Register();
        services.AddSingleton<MongoContext>();
        services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
    }
}
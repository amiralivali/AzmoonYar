using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Infrastructure.Persistance.Mongo;
using AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;
using AzmoonYar.Infrastructure.Persistance.Redis.Caching;
using AzmoonYar.Infrastructure.Persistance.Redis.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzmoonYar.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection builder)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            builder.AddDbContext<AzmoonYarDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("postgres")));
            builder.AddScoped<IBookRepository, BookRepository>();
            builder.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.AddScoped<IUserRepository, UserRepository>();
            builder.Decorate<IQuestionRepository, CachedQuestionRepository>();
            builder.AddMongo(configuration);
            builder.AddRedis(configuration);
        }

        private void AddMongo(IConfiguration configuration)
        {
            builder.Configure<MongoSettings>(configuration.GetSection(MongoSettings.SectionName));
            MongoMappingConfig.Register();
            builder.AddSingleton<MongoContext>();
            builder.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
        }

        private void AddRedis(IConfiguration configuration)
        {
            builder.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetConnectionString("Redis");
                    options.InstanceName = configuration["Redis:InstanceName"];
                }
            );
            builder.AddScoped<ICacheService, RedisCacheService>();
        }
    }
}
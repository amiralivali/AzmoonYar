using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Infrastructure.Caching.Redis;
using AzmoonYar.Infrastructure.Persistance.Mongo;
using AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;
using AzmoonYar.Infrastructure.Storage;
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
            builder.AddScoped<IExamRepository, ExamRepository>();
            builder.AddScoped<IFileStorage, LocalFileStorage>();
            builder.AddMongo(configuration);
            builder.AddRedis(configuration);
        }

        private void AddMongo(IConfiguration configuration)
        {
            builder.Configure<MongoSettings>(configuration.GetSection(MongoSettings.SectionName));
            MongoMappingConfig.Register();
            builder.AddSingleton<MongoContext>();
            builder.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
            builder.AddScoped<IActivityLogRepository, ActivityLogRepository>();
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
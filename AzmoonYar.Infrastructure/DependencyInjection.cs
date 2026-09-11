using Amazon.S3;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Infrastructure.Caching.Redis;
using AzmoonYar.Infrastructure.Hashing;
using AzmoonYar.Infrastructure.Persistance.Mongo;
using AzmoonYar.Infrastructure.Persistance.Mongo.Repositories;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore;
using AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Repositories;
using AzmoonYar.Infrastructure.Storage;
using AzmoonYar.Infrastructure.Storage.Arvan;
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
            builder.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            builder.Configure<ArvanStorageOptions>(configuration.GetSection(ArvanStorageOptions.SectionName));
            builder.AddSingleton<IAmazonS3>(sp =>
            {
                var opt = configuration.GetSection(ArvanStorageOptions.SectionName).Get<ArvanStorageOptions>()!;

                var config = new AmazonS3Config
                {
                    ServiceURL = opt.ServiceUrl,
                    ForcePathStyle = true,
                    AuthenticationRegion = opt.AuthenticationRegion
                };

                return new AmazonS3Client(opt.AccessKey, opt.SecretKey, config);
            });

            builder.AddScoped<IFileStorageService, S3FileStorageServiceService>();
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
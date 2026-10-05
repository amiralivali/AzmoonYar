using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Asp.Versioning;
using AzmoonYar.API.Filters;
using AzmoonYar.API.OpenApi;
using AzmoonYar.Application.Common;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Infrastructure.Authentication;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

namespace AzmoonYar.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddJwtAuthentication();
        services.AddApiVersioningAndOpenApi();
        services.AddControllersAndValidation();
        return services;
    }

    private static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services
            .AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
            .Configure<IOptions<JwtSetting>>((options, jwtSetting) =>
            {
                var setting = jwtSetting.Value;
                options.MapInboundClaims = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = setting.Issuer,
                    ValidateAudience = true,
                    ValidAudience = setting.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Key))
                };
                
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var userIdClaim = context.Principal?
                            .FindFirst(JwtRegisteredClaimNames.Sub);

                        var tokenVersionClaim = context.Principal?
                            .FindFirst(CustomClaimTypes.TokenVersion);

                        if (userIdClaim is null || tokenVersionClaim is null)
                        {
                            context.Fail("Invalid token.");
                            return;
                        }

                        if (!long.TryParse(userIdClaim.Value, out var userId))
                        {
                            context.Fail("Invalid user id.");
                            return;
                        }

                        if (!Guid.TryParse(tokenVersionClaim.Value, out var tokenVersion))
                        {
                            context.Fail("Invalid token version.");
                            return;
                        }

                        var userRepository =
                            context.HttpContext.RequestServices
                                .GetRequiredService<IUserRepository>();

                        var user = await userRepository.GetByIdAsync(userId);

                        if (user is null)
                        {
                            context.Fail("User not found.");
                            return;
                        }

                        if (user.TokenVersion != tokenVersion)
                        {
                            context.Fail("Token has been revoked.");
                            return;
                        }
                    }
                };
            });
        
    }
    private static void AddApiVersioningAndOpenApi(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.ReportApiVersions = true;
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddOpenApi(options => options.Document.AddScalarTransformers());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }

    private static void AddControllersAndValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
            options.Filters.Add<ApiResultFilter>();
        });
    }
}

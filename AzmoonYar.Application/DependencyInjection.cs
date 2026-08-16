using AzmoonYar.Application.Caching;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzmoonYar.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection builder)
    {
        builder.AddScoped<UserService>();
        builder.AddScoped<BookService>();
        builder.AddScoped<ExceptionLogService>();
        builder.AddScoped<QuestionService>();
        builder.AddScoped<QuestionCache>();
        builder.AddScoped<FillInBlankItemService>();
        builder.AddScoped<TrueFalseItemService>();
        builder.AddScoped<MatchingItemService>();
        builder.AddScoped<OptionalItemService>();
    }
}
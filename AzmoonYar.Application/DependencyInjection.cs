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
        builder.AddScoped<ExamService>();
        builder.AddScoped<ActivityLogService>();
        builder.AddScoped<ExceptionLogService>();
        builder.AddScoped<DashboardService>();
        builder.AddScoped<QuestionService>();
        builder.AddScoped<FillInBlankItemService>();
        builder.AddScoped<TrueFalseItemService>();
        builder.AddScoped<MatchingItemService>();
        builder.AddScoped<OptionalItemService>();
    }
}
using AzmoonYar.Application.Caching;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services;
using AzmoonYar.Application.Services.implementation;
using AzmoonYar.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzmoonYar.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection builder)
    {
        builder.AddScoped<IUserService, UserService>();
        builder.AddScoped<IBookService,BookService>();
        builder.AddScoped<IExamService,ExamService>();
        builder.AddScoped<IActivityLogService,ActivityLogService>();
        builder.AddScoped<IExceptionLogService,ExceptionLogService>();
        builder.AddScoped<IDashboardService,DashboardService>();
        builder.AddScoped<IQuestionService,QuestionService>();
        builder.AddScoped<IFillInBlankItemService,FillInBlankItemService>();
        builder.AddScoped<ITrueFalseItemService,TrueFalseItemService>();
        builder.AddScoped<IMatchingItemService,MatchingItemService>();
        builder.AddScoped<IOptionalItemService,OptionalItemService>();
        builder.AddScoped<DashboardCache>();
    }
}
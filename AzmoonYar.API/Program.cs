using System.Net;
using System.Text;
using Asp.Versioning;
using AzmoonYar.API;
using AzmoonYar.API.Extensions;
using AzmoonYar.API.Filters;
using AzmoonYar.API.Middlewares;
using AzmoonYar.Application;
using AzmoonYar.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Host.UseSerilog((ctx, service, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration)
        .ReadFrom.Services(service)
);

builder.Services.AddApi();


var app = builder.Build();
app.UseApiDocumentation();
app.UseSerilogRequestLogging();   
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
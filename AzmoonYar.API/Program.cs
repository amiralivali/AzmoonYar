using Asp.Versioning;
using AzmoonYar.API.Filters;
using AzmoonYar.API.Middlewares;
using AzmoonYar.Application;
using AzmoonYar.Infrastructure;
using FluentValidation;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<ApiResultFilter>();
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    })
    .AddOpenApi(options => options.Document.AddScalarTransformers());



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().WithDocumentPerVersion();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("AzmoonYar API");

        var descriptions = app.DescribeApiVersions();

        for (var index = 0; index < descriptions.Count; index++)
        {
            var description = descriptions[index];
            //var isDefault = index == descriptions.Count - 1;
            var isDefault = index == 0;

            options.AddDocument(
                description.GroupName,
                description.GroupName.ToUpperInvariant(),
                isDefault: isDefault);
        }
    });
    
    app.MapSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DisplayRequestDuration();

        foreach (var description in app.DescribeApiVersions())
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());        
        }
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
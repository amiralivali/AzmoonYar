using Scalar.AspNetCore;

namespace AzmoonYar.API.Extensions;

public static class WebApplicationExtensions
{
    public static void UseApiDocumentation(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.MapOpenApi().WithDocumentPerVersion();

        app.MapScalarApiReference(options =>
        {
            options.WithTitle("AzmoonYar API");

            var descriptions = app.DescribeApiVersions();

            for (var index = 0; index < descriptions.Count; index++)
            {
                var description = descriptions[index];

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
}
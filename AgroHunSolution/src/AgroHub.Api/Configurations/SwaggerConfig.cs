using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;

namespace AgroHub.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void VersionConfig(this WebApplicationBuilder app)
        {
            // Adicionar versionamento de API
            app.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            // Adicionar suporte para versionamento via URL segment
            app.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            app.Services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            app.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        public static void AddSwaggerGen(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }
        }
    }
}

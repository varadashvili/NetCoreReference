using System.Reflection;

using Microsoft.OpenApi.Models;

namespace UsefulPackagesDemo.Common.Swagger;

public static class DependencyInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                name: "v2",
                info: new OpenApiInfo
                {
                    Title = "DemoApp.DemoApi",
                    Version = "v2",
                });

            options.ResolveConflictingActions(r => r.First());

            options.SwaggerDoc(
               name: "v3",
               info: new OpenApiInfo
               {
                   Title = "DemoApp.DemoApi",
                   Version = "v3",
               });

            options.AddSecurityDefinition(
                name: "Bearer",
                securityScheme: new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.  Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

            options.AddSecurityRequirement(
                securityRequirement: new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

        });

        return services;
    }

    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        //if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(url: "/swagger/v2/swagger.json", name: "DemoApp.DemoAp v2");
                options.SwaggerEndpoint(url: "/swagger/v3/swagger.json", name: "DemoApp.DemoAp v3");
            });
        }

        return app;
    }
}

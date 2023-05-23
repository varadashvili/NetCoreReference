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
                name: "v1",
                info: new OpenApiInfo
                {
                    Title = "DemoApp.DemoApi",
                    Version = "v1",
                });

            var filePath = Path.Combine(AppContext.BaseDirectory, "ApiDoc.xml");
            options.IncludeXmlComments(filePath);
        });

        return services;
    }

    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        //if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json",
                name: "DemoApp.DemoAp v1"));
        }

        return app;
    }
}

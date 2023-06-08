using UsefulPackagesDemo.Common.ObjectMapping.Mapster;
using UsefulPackagesDemo.Common.SwaggerDoc;
using UsefulPackagesDemo.Common.Versioning;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddSwagger();

    builder.Services.AddVersioning();

    builder.Services.AddMapsterMappings();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.ConfigureSwagger();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
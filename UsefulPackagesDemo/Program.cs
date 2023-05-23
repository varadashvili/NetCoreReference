using UsefulPackagesDemo.Common.Swagger;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddSwagger();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.ConfigureSwagger();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
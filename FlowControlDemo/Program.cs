using FlowControlDemo.Application;
using FlowControlDemo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services
        .AddInfrastructure()
        .AddApplication();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
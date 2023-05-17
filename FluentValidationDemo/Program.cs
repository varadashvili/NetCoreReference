using FluentValidation;
using FluentValidation.AspNetCore;

using FluentValidationDemo.Common;
using FluentValidationDemo.Services.DateTimeProvider;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddFluentValidationAutoValidation(fv =>
    {
        fv.DisableDataAnnotationsValidation = true;
    });

    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

    builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
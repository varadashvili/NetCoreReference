using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    //error handling using custom filter
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    //error handling using error controller,  ProblemDetails and custom ProblemDetailsFactory
    //builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "UserApi",
            Version = "v1"
        });

        var filePath = Path.Combine(AppContext.BaseDirectory, "Documentation\\UserApi.xml");
        c.IncludeXmlComments(filePath);
    });

    builder.Services.AddSingleton<IUserService, UserService>();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        //app.UseDeveloperExceptionPage();
    }
    else
    {
        //error handling using custom middleware
        //app.UseMiddleware<ErrorHandlingMiddleware>();
    }

    //error handling using error controller,  ProblemDetails 
    app.UseExceptionHandler("/error");

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserApi v1"));

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
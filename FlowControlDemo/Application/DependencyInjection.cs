using FlowControlDemo.Application.Common;
using FlowControlDemo.Application.Common.Interfaces.Services;
using FlowControlDemo.Application.Common.Services;

using FluentValidation;
using FluentValidation.AspNetCore;

namespace FlowControlDemo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>(ServiceLifetime.Singleton);

        services.AddSingleton<ITaskItemService, TaskItemService>();

        return services;
    }
}
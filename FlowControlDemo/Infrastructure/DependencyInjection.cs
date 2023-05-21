using FlowControlDemo.Application.Common.Interfaces.Persistence;
using FlowControlDemo.Application.Common.Interfaces.Services;
using FlowControlDemo.Infrastructure.Persistence;
using FlowControlDemo.Infrastructure.Services;

namespace FlowControlDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddSingleton<ITaskItemRepository, TaskItemRepository>();

        return services;
    }
}

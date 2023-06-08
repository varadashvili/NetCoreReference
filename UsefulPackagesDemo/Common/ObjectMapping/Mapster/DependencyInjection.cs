﻿using System.Reflection;

using Mapster;

using MapsterMapper;

namespace UsefulPackagesDemo.Common.ObjectMapping.Mapster;

public static class DependencyInjection
{
    public static IServiceCollection AddMapsterMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
﻿namespace EarlierBird.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}

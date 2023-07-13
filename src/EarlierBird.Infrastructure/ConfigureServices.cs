using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace EarlierBird.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDatabase, Database>();
        return services;
    }
}
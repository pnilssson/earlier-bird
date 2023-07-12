using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EarlierBird.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPackageService, PackageService>();
        return services;
    }
}
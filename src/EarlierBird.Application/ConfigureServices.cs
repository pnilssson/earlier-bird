using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Models.Requests;
using EarlierBird.Application.Services;
using EarlierBird.Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EarlierBird.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPackageService, PackageService>();
        services.AddScoped<IValidator<PackageGetRequest>, PackageGetRequestValidator>();
        return services;
    }
}
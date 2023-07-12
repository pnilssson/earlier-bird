using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Models.Requests;
using EarlierBird.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EarlierBird.Application.Services;

public class PackageService : IPackageService
{
    private readonly IDatabase _database;
    private readonly ILogger<PackageService> _logger;

    public PackageService(IDatabase database, ILogger<PackageService> logger)
    {
        _database = database;
        _logger = logger;
    }

    public Package? GetPackage(string packageId)
    {
        var package = _database.GetPackage(packageId);

        _logger.LogInformation($"Retrived package: {JsonSerializer.Serialize(package)}.");
        return package;
    }

    public IReadOnlyCollection<Package> GetAllPackages()
    {
        var packages = _database.GetAllPackages();

        _logger.LogInformation($"Retrived all packages.");
        return packages;
    }

    public Package AddPackage(PackageCreateRequest packageRequest)
    {
        var package = new Package(packageRequest.Weight, packageRequest.Length, packageRequest.Height, packageRequest.Width);
        var newPackage = _database.AddPackage(package);

        _logger.LogInformation($"Added package: {JsonSerializer.Serialize(newPackage)}.");
        return newPackage;
    }
}

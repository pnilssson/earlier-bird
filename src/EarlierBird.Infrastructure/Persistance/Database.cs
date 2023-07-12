using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Domain.Entities;
using System.Collections.ObjectModel;

namespace EarlierBird.Infrastructure.Persistance;

public class Database : IDatabase
{
    private Collection<Package> _packages = new Collection<Package>();

    public Package AddPackage(Package package)
    {
        _packages.Add(package);
        return package;
    }

    public Package? GetPackage(string id)
    {
        return _packages.FirstOrDefault(a => a.Id == id);
    }

    public IReadOnlyCollection<Package> GetAllPackages() => _packages;
}

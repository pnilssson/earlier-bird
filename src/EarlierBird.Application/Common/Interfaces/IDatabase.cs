using EarlierBird.Domain.Entities;

namespace EarlierBird.Application.Common.Interfaces;

public interface IDatabase
{
    public Package AddPackage(Package package);

    public Package? GetPackage(string id);

    public IReadOnlyCollection<Package> GetAllPackages();
}

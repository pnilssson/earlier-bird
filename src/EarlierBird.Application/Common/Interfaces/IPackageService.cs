using EarlierBird.Application.Models.Requests;
using EarlierBird.Domain.Entities;

namespace EarlierBird.Application.Common.Interfaces;

public interface IPackageService
{
    Package? GetPackage(string packageId);

    IReadOnlyCollection<Package> GetAllPackages();

    Package AddPackage(PackageCreateRequest packageRequest);
}

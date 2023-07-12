using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EarlierBird.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPackage(string id)
        {
            var package = _packageService.GetPackage(id);

            if (package is null)
                return NotFound($"No package with id {id} could be found.");

            return Ok(package);
        }

        [HttpGet]
        public IActionResult GetAllPackages()
        {
            var packages = _packageService.GetAllPackages();
            return Ok(packages);
        }

        [HttpPost]
        public IActionResult AddPackage(PackageCreateRequest packageRequest)
        {
            var newPackage = _packageService.AddPackage(packageRequest);
            return Ok(newPackage);
        }
    }
}
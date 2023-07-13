using EarlierBird.Application.Common.Extensions;
using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Models.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EarlierBird.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        private IValidator<PackageGetRequest> _packageGetValidator;

        public PackageController(IPackageService packageService, IValidator<PackageGetRequest> packageGetValidator)
        {
            _packageService = packageService;
            _packageGetValidator = packageGetValidator;
        }

        [HttpGet("{Id}")]
        public IActionResult GetPackage([FromRoute] PackageGetRequest request)
        {
            var validationResult = _packageGetValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessages());
            }

            var package = _packageService.GetPackage(request.Id);

            if (package is null)
                return NotFound($"No package with id {request.Id} could be found.");

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
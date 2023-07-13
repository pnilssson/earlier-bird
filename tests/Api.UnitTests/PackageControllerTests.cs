using EarlierBird.Api.Controllers;
using EarlierBird.Application.Common.Interfaces;
using EarlierBird.Application.Models.Requests;
using EarlierBird.Application.Validation;
using EarlierBird.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.UnitTests
{
    public class PackageControllerTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("9991")]
        [InlineData("123abc")]
        public void GetPackage_WithInvalidData_ShouldReturnBadRequest(string id)
        {
            // Arrange
            var packageController = GetPackageController();
            var request = new PackageGetRequest()
            {
                Id = id
            };

            // Act
            var result = packageController.GetPackage(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetPackage_WithNonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var packageService = new Mock<IPackageService>();
            packageService.Setup(a => a.GetPackage(It.IsAny<string>())).Returns<Package>(null);
            var packageController = new PackageController(packageService.Object, new PackageGetRequestValidator());

            var request = new PackageGetRequest()
            {
                Id = "999456789123456789"
            };

            // Act
            var result = packageController.GetPackage(request);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        private PackageController GetPackageController()
        {
            var packageService = new Mock<IPackageService>();
            return new PackageController(packageService.Object, new PackageGetRequestValidator());
        }
    }
}
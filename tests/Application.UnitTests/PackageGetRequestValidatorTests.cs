using EarlierBird.Application.Models.Requests;
using EarlierBird.Application.Validation;
using FluentValidation.TestHelper;

namespace Application.UnitTests;

public class PackageGetRequestValidatorTests
{
    [Fact]
    public void Validate_WithoutStartingWith999_ShouldReturnError()
    {
        // Arrange
        var validator = new PackageGetRequestValidator();
        var request = new PackageGetRequest("123456789123456789");

        // Assert
        var result = validator.TestValidate(request);

        // Act
        result.ShouldHaveValidationErrorFor(a => a.Id)
            .WithErrorMessage("'Id' must start with '999'.");
    }

    [Fact]
    public void Validate_WithoutOnlyNumbers_ShouldReturnError()
    {
        // Arrange
        var validator = new PackageGetRequestValidator();
        var request = new PackageGetRequest("999abc789123456789");

        // Assert
        var result = validator.TestValidate(request);

        // Act
        result.ShouldHaveValidationErrorFor(a => a.Id)
            .WithErrorMessage("'Id' must only contain numbers.");
    }

    [Fact]
    public void Validate_WithToShortId_ShouldReturnError()
    {
        // Arrange
        var validator = new PackageGetRequestValidator();
        var request = new PackageGetRequest("999123");

        // Assert
        var result = validator.TestValidate(request);

        // Act
        result.ShouldHaveValidationErrorFor(a => a.Id)
            .WithErrorMessage("'Id' must be 18 characters in length. You entered 6 characters.");
    }
}

using EarlierBird.Application.Models.Requests;
using FluentValidation;

namespace EarlierBird.Application.Validation;

public class PackageGetRequestValidator : AbstractValidator<PackageGetRequest>
{
    public PackageGetRequestValidator()
    {
        RuleFor(a => a.Id).Length(18);
        RuleFor(a => a.Id).Must(b => b.StartsWith("999")).WithMessage("'Id' must start with '999'.");
        RuleFor(a => a.Id).Matches("/^\\d+$/").WithMessage("'Id' must only contain numbers.");
    }
}

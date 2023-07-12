using FluentValidation.Results;

namespace EarlierBird.Application.Common.Extensions;

public static class ValidationResultExtensions
{
    public static IEnumerable<string> ErrorMessages(this ValidationResult @this)
    {
        return @this.Errors.Select(a => a.ErrorMessage);
    }
}

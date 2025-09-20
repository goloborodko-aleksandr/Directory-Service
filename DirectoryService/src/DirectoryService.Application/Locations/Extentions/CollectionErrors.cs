using FluentValidation.Results;
using Shared;

namespace DirectoryService.Application.Locations.Extentions;

public static class CollectionErrors
{
    public static Failure ToValidationErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(error => Error.Validation(error.ErrorCode, error.ErrorMessage, error.PropertyName)).ToArray();
    }
}
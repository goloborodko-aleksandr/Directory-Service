namespace Shared;

public sealed class GeneralError
{
    public static Error ValueIsRequired(string value) =>
        Error.NotFound("value.is.required", null, $"{value} is required");

    public static Error ValueIsInvalid(string? invalidField) =>
        Error.Validation("value.is.not.valid", $"value {invalidField ?? "unknown"} is not valid", invalidField);

    public static Error ValueIsFailure() =>
        Error.Failure("value.failure", "Something is failed");

    public static Error ValueIsConflict() =>
        Error.Conflict("value.conflict", "Something is conflict");
}
namespace Shared;

public record Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorType ErrorType { get; }
    public string? InvalidField { get; }

    private Error(string code, string message, ErrorType errorType, string? invalidField = null)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
        InvalidField = invalidField;
    }

    public static Error Validation(string? code, string message, string? invalidField) => new(code ?? "value.is.not.valid", message, ErrorType.VALIDATION, invalidField);
    public static Error NotFound(string? code, Guid? id, string message) => new(code ?? "record.not.found", message, ErrorType.NOT_FOUND);
    public static Error Failure(string? code, string message) => new(code ?? "failure", message, ErrorType.FAILURE);
    public static Error Conflict(string? code, string message) => new(code ?? "conflict", message, ErrorType.CONFLICT);
    public Failure ToFailure() => this;
}
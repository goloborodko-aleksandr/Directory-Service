using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.DepartmentEntity;

public sealed record Path
{
    private readonly char _separator = '/';
    public string Value { get; }

    private Path(Identifier? parentIdentitifier, Identifier identifier)
    {
        Value = parentIdentitifier != null ? parentIdentitifier.Value + _separator + identifier : identifier.Value;
    }

    public static Result<Path, Failure> Create(Identifier? parentIdentitifier, Identifier identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier.Value) || Regex.IsMatch(identifier.Value, "^[a-zA-Z0-9.-]*$"))
        {
            return GeneralError.ValueIsInvalid("department path").ToFailure();
        }

        return new Path(parentIdentitifier, identifier);
    }
}
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.LocationEntity;

public sealed record Name
{
    public const int MIN_LENGTH = 2;
    public const int MAX_LENGTH = 120;

    public readonly string Value;

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name, Failure> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return GeneralError.ValueIsInvalid("location name").ToFailure();
        }

        return new Name(value);
    }
}
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.PositionEntity;

public sealed record Name
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 100;

    public string Value { get; private set; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name, Failure> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return GeneralError.ValueIsInvalid("position name").ToFailure();
        }

        return new Name(value);
    }
}
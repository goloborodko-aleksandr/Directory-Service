using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.LocationEntity;

public record Name
{
    public const int MIN_LENGTH = 2;
    public const int MAX_LENGTH = 120;

    public readonly string Value;

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH || string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Name>("No correct location name");
        }

        return Result.Success(new Name(value));
    }
}
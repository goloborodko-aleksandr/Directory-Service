using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public record Name
{
    public const short MIN_LENGTH = 2;
    public const short MAX_LENGTH = 100;

    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH || string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Name>("No correct department name");
        }

        return Result.Success(new Name(value));
    }
};
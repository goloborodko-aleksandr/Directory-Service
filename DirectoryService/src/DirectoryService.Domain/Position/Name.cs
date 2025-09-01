using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Position;

public record Name
{
    private const int MIN_LENGTH = 2;
    private const int MAX_LENGTH = 100;

    public string Value { get; private set; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH || string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Name>("No correct position name");
        }

        return Result.Success(new Name(value));
    }
}
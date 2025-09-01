using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public record Identifier
{
    public const short MIN_LENGTH = 2;
    public const short MAX_LENGTH = 150;

    public string Value { get; }

    private Identifier(string value)
    {
        Value = value;
    }

    public static Result<Identifier> Create(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH ||
            string.IsNullOrWhiteSpace(value) || Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
        {
            return Result.Failure<Identifier>("No correct department identifier");
        }

        return Result.Success(new Identifier(value));
    }
}
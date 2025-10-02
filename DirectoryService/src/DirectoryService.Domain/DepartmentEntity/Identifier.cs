using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.DepartmentEntity;

public sealed record Identifier
{
    public const short MIN_LENGTH = 2;
    public const short MAX_LENGTH = 150;

    public string Value { get; }

    private Identifier(string value)
    {
        Value = value;
    }

    public static Result<Identifier, Failure> Create(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH ||
            string.IsNullOrWhiteSpace(value) || Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
        {
            return GeneralError.ValueIsInvalid("Identifier").ToFailure();
        }

        return new Identifier(value);
    }
}
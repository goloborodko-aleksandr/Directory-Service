using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.DepartmentEntity;

public sealed record Name
{
    public const short MIN_LENGTH = 3;
    public const short MAX_LENGTH = 150;

    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name, Failure> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return GeneralError.ValueIsInvalid("Department name").ToFailure();
        }

        return new Name(value);
    }
};
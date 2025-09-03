using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.DepartmentEntity;

public record Path
{
    public string Value { get; }

    private Path(string value)
    {
        Value = value;
    }

    public static Result<Path> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || Regex.IsMatch(value, "^[a-zA-Z0-9.-]*$"))
        {
            return Result.Failure<Path>("No correct department path");
        }

        return Result.Success(new Path(value));
    }
}
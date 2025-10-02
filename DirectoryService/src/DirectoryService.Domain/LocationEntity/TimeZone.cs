using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.LocationEntity;

public sealed record TimeZone
{
    public string Value { get; }

    private TimeZone(string value)
    {
        Value = value;
    }

    public static Result<TimeZone, Failure> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return GeneralError.ValueIsInvalid("location time zone").ToFailure();
        }

        return new TimeZone(value);
    }
}
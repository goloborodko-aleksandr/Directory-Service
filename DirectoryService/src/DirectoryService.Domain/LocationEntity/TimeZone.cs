using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.LocationEntity;

public record TimeZone
{
    public string Value { get; }

    private TimeZone(string value)
    {
        Value = value;
    }

    public static Result<TimeZone> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<TimeZone>("No correct time zone");
        }

        return Result.Success(new TimeZone(value));
    }
}
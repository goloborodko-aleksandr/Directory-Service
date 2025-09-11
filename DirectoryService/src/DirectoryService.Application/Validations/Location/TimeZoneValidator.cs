using DirectoryService.Contracts.Locations;
using FluentValidation;
using NodaTime;

namespace DirectoryService.Application.Validations.Location;

public class TimeZoneValidator: AbstractValidator<TimeZoneDto>
{
    public TimeZoneValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Not empty")
            .Must(IsTimeZoneValid).WithMessage("Invalid time zone");
    }

    private bool IsTimeZoneValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return DateTimeZoneProviders.Tzdb.Ids.Contains(value);
    }
}
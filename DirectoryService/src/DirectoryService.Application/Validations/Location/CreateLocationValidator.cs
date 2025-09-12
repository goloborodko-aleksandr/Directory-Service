using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Validations.Location;

public class CreateLocationValidator: AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name).SetValidator(new NameValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.TimeZone).SetValidator(new TimeZoneValidator());
        RuleForEach(x => x.DepartmentLocations).NotEmpty().WithMessage("Department locations should not be empty");
    }
}
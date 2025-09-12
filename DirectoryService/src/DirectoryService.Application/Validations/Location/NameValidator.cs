using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Validations.Location;

public class NameValidator : AbstractValidator<NameDto>
{
    public NameValidator()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Not empty");
    }
}
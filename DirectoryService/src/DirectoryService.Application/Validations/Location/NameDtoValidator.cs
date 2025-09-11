using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Validations.Location;

public class NameDtoValidator : AbstractValidator<NameDto>
{
    private NameDtoValidator()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Not empty");
    }
}
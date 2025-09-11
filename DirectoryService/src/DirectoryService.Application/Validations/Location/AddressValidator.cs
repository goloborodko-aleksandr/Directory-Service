using DirectoryService.Contracts.Locations;
using FluentValidation;

namespace DirectoryService.Application.Validations.Location;

public class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .Matches("^[A-Z][a-zA-Z]*$") // латиница, первая буква заглавная
            .WithMessage("Country name should be in Latin and start with uppercase letter");

        RuleFor(x => x.Region)
            .NotEmpty()
            .Matches("^[A-Z][a-zA-Z]*$")
            .WithMessage("Region name should be in Latin and start with uppercase letter");

        RuleFor(x => x.City)
            .NotEmpty()
            .Matches("^[A-Z][a-zA-Z]*$")
            .WithMessage("City name should be in Latin and start with uppercase letter");

        RuleFor(x => x.Street)
            .NotEmpty()
            .Matches("^[A-Z][a-zA-Z]*$")
            .WithMessage("Street name should be in Latin and start with uppercase letter");

        RuleFor(x => x.District)
            .Matches("^[A-Z][a-zA-Z]*$")
            .When(x => !string.IsNullOrEmpty(x.District))
            .WithMessage("District name should be in Latin and start with uppercase letter");

        RuleFor(x => x.HouseNumber)
            .Matches("^[a-zA-Z0-9./-]+$")
            .When(x => !string.IsNullOrEmpty(x.HouseNumber))
            .WithMessage("HouseNumber should contain only Latin letters, numbers or ./-");

        RuleFor(x => x.Building)
            .Matches("^[a-zA-Z0-9./-]+$")
            .When(x => !string.IsNullOrEmpty(x.Building))
            .WithMessage("Building should contain only Latin letters, numbers or ./-");

        RuleFor(x => x.Apartment)
            .Matches("^[a-zA-Z0-9./-]+$")
            .When(x => !string.IsNullOrEmpty(x.Apartment))
            .WithMessage("Apartment should contain only Latin letters, numbers or ./-");

        RuleFor(x => x.ZipCode)
            .Matches("^[a-zA-Z0-9]+$")
            .When(x => !string.IsNullOrEmpty(x.ZipCode))
            .WithMessage("ZipCode should contain only numbers and Latin letters");
    }
}
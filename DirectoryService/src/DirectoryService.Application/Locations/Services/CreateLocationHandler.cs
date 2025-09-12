using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.LocationEntity;
using FluentValidation;
using TimeZone = DirectoryService.Domain.LocationEntity.TimeZone;

namespace DirectoryService.Application.Locations.Services;

public class CreateLocationHandler
{
    private readonly ILocationsRepository _locationsRepository;
    private readonly IValidator<CreateLocationDto> _validator;

    public CreateLocationHandler(ILocationsRepository locationsRepository, IValidator<CreateLocationDto> validator)
    {
        _locationsRepository = locationsRepository;
        _validator = validator;
    }

    public async Task Handle(CreateLocationDto createLocationDto, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(createLocationDto, cancellationToken);

        if (!validatorResult.IsValid)
        {
            validatorResult.Errors.ForEach(i => Console.WriteLine(i.ErrorMessage));
            Console.WriteLine(validatorResult.Errors);
            return;
        }

        var name = Name.Create(createLocationDto.Name.Value);
        var address = Address.Create(
            country: createLocationDto.Address.Country,
            region: createLocationDto.Address.Region,
            city: createLocationDto.Address.City,
            street: createLocationDto.Address.Street,
            district: createLocationDto.Address.District,
            houseNumber: createLocationDto.Address.HouseNumber,
            building: createLocationDto.Address.Building,
            apartment: createLocationDto.Address.Apartment,
            zipCode: createLocationDto.Address.ZipCode,
            additionalInfo: createLocationDto.Address.AdditionalInfo);
        var timeZone = TimeZone.Create(createLocationDto.TimeZone.Value);
        var location = Location.Create(name.Value, address.Value, timeZone.Value, createLocationDto.DepartmentLocations, createLocationDto.IsActive);
        var locationId = await _locationsRepository.AddAsync(location.Value, cancellationToken);
    }
}
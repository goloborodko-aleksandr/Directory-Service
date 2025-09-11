namespace DirectoryService.Contracts.Locations;

public record AddressDto(
    string Country,
    string Region,
    string City,
    string Street,
    string? District,
    string? HouseNumber,
    string? Building,
    string? Apartment,
    string? ZipCode,
    string? AdditionalInfo);
using DirectoryService.Domain.ConnectionEntity;


namespace DirectoryService.Contracts.Locations;

public record CreateLocationDto(
    NameDto Name,
    AddressDto Address,
    TimeZoneDto TimeZone,
    bool IsActive,
    IEnumerable<DepartmentLocation> DepartmentLocations);
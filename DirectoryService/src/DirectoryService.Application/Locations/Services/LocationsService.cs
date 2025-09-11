using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.LocationEntity;
using TimeZone = DirectoryService.Domain.LocationEntity.TimeZone;

namespace DirectoryService.Application.Locations.Services;

public class LocationsService
{
    private readonly ILocationsRepository _locationsRepository;

    private LocationsService(ILocationsRepository locationsRepository)
    {
        _locationsRepository = locationsRepository;
    }

    public async Task Create(CreateLocationDto createLocationDto, CancellationToken cancellationToken)
    {
        
    }

    public async Task Delete()
    {
        throw new NotImplementedException();
    }

}
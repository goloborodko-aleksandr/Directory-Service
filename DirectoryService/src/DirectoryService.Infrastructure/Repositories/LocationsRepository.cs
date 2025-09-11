using DirectoryService.Application.Locations;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Infrastructure.Repositories;

public class LocationsRepository : ILocationsRepository
{
    public Task<Guid> AddAsync(Location location, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> UpdateAsync(Location location, CancellationToken cancellationToken) => throw new NotImplementedException();
}
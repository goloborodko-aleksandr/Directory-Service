using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Application.Locations;

public interface ILocationsRepository
{
    Task<Guid> AddAsync(Location location, CancellationToken cancellationToken);

    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);

    Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> UpdateAsync(Location location, CancellationToken cancellationToken);
}
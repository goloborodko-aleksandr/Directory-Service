using DirectoryService.Application.Locations.Repositories;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Infrastructure.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private DirectoryServiceDbContext _dbContext;

    public LocationsRepository(DirectoryServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddAsync(Location location, CancellationToken cancellationToken)
    {
        await _dbContext.Locations.AddAsync(location);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return location.Id;
    }

    public Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> UpdateAsync(Location location, CancellationToken cancellationToken) => throw new NotImplementedException();
}
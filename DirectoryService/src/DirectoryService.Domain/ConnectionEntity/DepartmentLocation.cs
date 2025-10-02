using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public sealed class DepartmentLocation
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; } = null!;

    public Location Location { get; private set; } = null!;

    // EF Core
    private DepartmentLocation() { }

    public DepartmentLocation(
        Department department,
        Location location)
    {
        Id = Guid.NewGuid();
        Department = department;
        Location = location;
    }
}
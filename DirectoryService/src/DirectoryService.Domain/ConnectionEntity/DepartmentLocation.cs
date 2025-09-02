using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentLocation
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; }

    public Location Location { get; private set; }

    public DepartmentLocation(
        Department department,
        Location location)
    {
        Id = Guid.NewGuid();
        Department = department;
        Location = location;
    }
}
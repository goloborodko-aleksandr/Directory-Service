using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentLocation
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; }

    public Location Location { get; private set; }

    private DepartmentLocation(
        Department department,
        Location location)
    {
        Id = Guid.NewGuid();
        Department = department;
        Location = location;
    }

    public static Result<DepartmentLocation> Create(
        Department department,
        Location location)
    {
        if (department == null || location == null)
            return Result.Failure<DepartmentLocation>("Department or Location cannot be null");

        return new DepartmentLocation(department, location);
    }
}
using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.LocationEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentLocation
{
    public Department Department { get; private set; }

    public Location Location { get; private set; }

    private DepartmentLocation(
        Department department,
        Location location)
    {
        Department = department;
        Location = location;
    }

    public static Result<DepartmentLocation> Create(
        Department? department,
        Location? location)
    {
        if (department == null)
            return Result.Failure<DepartmentLocation>("Department cannot be null");

        if (location == null)
            return Result.Failure<DepartmentLocation>("Position cannot be null");

        return new DepartmentLocation(department, location);
    }
}
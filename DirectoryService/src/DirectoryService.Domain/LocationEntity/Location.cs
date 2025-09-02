using CSharpFunctionalExtensions;
using DirectoryService.Domain.ConnectionEntity;

namespace DirectoryService.Domain.LocationEntity;

public class Location
{
    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public TimeZone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentLocation> _departmentLocations;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    private Location(
        Name name,
        Address address,
        TimeZone timezone,
        List<DepartmentLocation> departmentLocations,
        bool isActive)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Name = name;
        Address = address;
        Timezone = timezone;
        _departmentLocations = departmentLocations;
        IsActive = isActive;
    }

    public static Result<Location> Create(
        Name name,
        Address address,
        TimeZone timezone,
        List<DepartmentLocation>? departmentLocations,
        bool isActive)
    {
        if (departmentLocations == null)
        {
            return Result.Failure<Location>("departmentLocations cannot be null");
        }

        return Result.Success(new Location(name, address, timezone, departmentLocations, isActive));
    }
}
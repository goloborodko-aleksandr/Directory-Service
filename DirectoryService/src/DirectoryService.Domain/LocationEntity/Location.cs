using CSharpFunctionalExtensions;
using DirectoryService.Domain.ConnectionEntity;
using Shared;

namespace DirectoryService.Domain.LocationEntity;

public sealed class Location
{
    public Guid Id { get; private set; }

    public Name Name { get; private set; } = null!;

    public Address Address { get; private set; } = null!;

    public TimeZone Timezone { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentLocation> _departmentLocations = [];

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    public bool EmptyLocations => _departmentLocations.Count == 0;

    // EF Core
    private Location() { }

    public Location(
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
        IEnumerable<DepartmentLocation> departmentLocations,
        bool isActive)
    {
        return new Location(name, address, timezone, departmentLocations.ToList(), isActive);
    }
}
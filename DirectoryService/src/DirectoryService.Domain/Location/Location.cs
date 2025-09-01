using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location;

public class Location
{
    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public TimeZone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<Guid> _departments;

    public IReadOnlyList<Guid> Departments => _departments;

    public bool IsEmptyDepartments => _departments.Count == 0;

    private Location(
        Name name,
        Address address,
        TimeZone timezone,
        List<Guid> departments,
        bool isActive)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Name = name;
        Address = address;
        Timezone = timezone;
        _departments = departments;
        IsActive = isActive;
    }

    public static Result<Location> Create(
        Name name,
        Address address,
        TimeZone timezone,
        IEnumerable<Guid>? departments,
        bool isActive)
    {
        if (departments == null)
        {
            return Result.Failure<Location>("Departments is required");
        }

        return Result.Success(new Location(name, address, timezone, departments.ToList(), isActive));
    }
}
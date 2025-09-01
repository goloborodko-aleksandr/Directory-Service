using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Position;

public class Position
{
    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public List<Guid> Departments { get; private set; }

    public List<Guid> Locations { get; private set; }

    public bool IsEmptyDepartments => Departments.Count == 0;

    public bool IsEmptyLocations => Locations.Count == 0;

    private Position(
        Name name,
        string? description,
        List<Guid> departments,
        List<Guid> locations)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        Name = name;
        Description = description;
        Departments = departments;
        Locations = locations;
    }

    public static Result<Position> Create(
        Name name,
        string? description,
        IEnumerable<Guid> departments,
        IEnumerable<Guid> locations)
    {
        return new Position(
            name,
            description,
            departments.ToList() ?? new List<Guid>(),
            locations.ToList() ?? new List<Guid>());
    }
}
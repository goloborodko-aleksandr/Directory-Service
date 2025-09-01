using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Position;

public class Position
{
    public const short DESCRIPTION_MAX_LENGTH = 1500;

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<Guid> _departmens;

    private List<Guid> _locations;

    public IReadOnlyList<Guid> Departments => _departmens;

    public IReadOnlyList<Guid> Locations => _locations;

    public bool IsEmptyDepartments => Departments.Count == 0;

    public bool IsEmptyLocations => Locations.Count == 0;

    private Position(
        Name name,
        string? description,
        List<Guid> departments,
        List<Guid> locations,
        bool isActive)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Name = name;
        Description = description;
        _departmens = departments;
        _locations = locations;
        IsActive = isActive;
    }

    public static Result<Position> Create(
        Name name,
        string? description,
        IEnumerable<Guid>? departments,
        IEnumerable<Guid>? locations,
        bool isActive)
    {
        if (departments == null)
        {
            return Result.Failure<Position>("Departments is required");
        }

        if (locations == null)
        {
            return Result.Failure<Position>("Locations is required");
        }

        if (description is { Length: >= DESCRIPTION_MAX_LENGTH })
        {
            return Result.Failure<Position>("Description is too long");
        }

        return new Position(
            name,
            description,
            departments.ToList(),
            locations.ToList(),
            isActive);
    }
}
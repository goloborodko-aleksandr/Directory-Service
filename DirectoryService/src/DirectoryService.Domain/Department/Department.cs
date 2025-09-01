using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department;

public class Department
{
    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Identifier Identifier { get; private set; }

    public Path Path { get; private set; }

    public Guid? ParentId { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<Department> _children;

    public IReadOnlyList<Department> Children => _children;

    private List<Guid> _positions;

    public IReadOnlyList<Guid> Positions => _positions;

    private List<Guid> _locations;

    public IReadOnlyList<Guid> Locations => _locations;

    public bool IsRoot => ParentId == null;

    public bool IsLeaf => Children.Count == 0;

    public bool IsEmptyPositions => Positions.Count == 0; // nominal

    public bool IsEmptyLocations => Locations.Count == 0; // remote work

    private Department(
        Name name,
        Identifier identifier,
        Path path,
        Guid? parentId,
        short depth,
        bool isActive,
        List<Department> children,
        List<Guid> positions,
        List<Guid> locations)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        Name = name;
        Identifier = identifier;
        Path = path;
        ParentId = parentId;
        Depth = depth;
        IsActive = isActive;
        _children = children;
        _positions = positions;
        _locations = locations;
    }

    public static Result<Department> Create(
        Name name,
        Identifier identifier,
        Path path,
        Guid? parentId,
        short depth,
        bool isActive,
        IEnumerable<Department> children,
        IEnumerable<Guid> positions,
        IEnumerable<Guid> locations)
    {
        return new Department(
            name,
            identifier,
            path,
            parentId,
            depth,
            isActive,
            children.ToList() ?? new List<Department>(),
            positions.ToList() ?? new List<Guid>(),
            locations.ToList() ?? new List<Guid>());
    }
}
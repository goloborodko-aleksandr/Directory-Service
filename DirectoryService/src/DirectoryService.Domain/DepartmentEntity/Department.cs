using CSharpFunctionalExtensions;
using DirectoryService.Domain.ConnectionEntity;

namespace DirectoryService.Domain.DepartmentEntity;

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

    private List<DepartmentPosition> _departmentPosition;

    private List<DepartmentLocation> _departmentLocation;

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPosition;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocation;

    public bool IsRoot => ParentId == Guid.Empty;

    public bool IsLeaf => _children.Count == 0;

    public bool EmptyPositions => _departmentPosition.Count == 0;

    public bool EmptyLocations => _departmentLocation.Count == 0;

    private Department(
        Name name,
        Identifier identifier,
        Path path,
        Guid? parentId,
        short depth,
        bool isActive,
        List<Department> children,
        List<DepartmentPosition> departmentPosition,
        List<DepartmentLocation> departmentLocation)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Name = name;
        Identifier = identifier;
        Path = path;
        ParentId = parentId;
        Depth = depth;
        IsActive = isActive;
        _children = children;
        _departmentPosition = departmentPosition;
        _departmentLocation = departmentLocation;
    }

    public static Result<Department> Create(
        Name name,
        Identifier identifier,
        Path path,
        Guid? parentId,
        short depth,
        bool isActive,
        IEnumerable<Department>? children,
        IEnumerable<DepartmentPosition>? departmentPosition,
        IEnumerable<DepartmentLocation>? departmentLocation)
    {
        if (depth <= 0)
            return Result.Failure<Department>("Depth cannot be negative");

        return new Department(
            name,
            identifier,
            path,
            parentId,
            depth,
            isActive,
            children?.ToList() ?? [],
            departmentPosition?.ToList() ?? [],
            departmentLocation?.ToList() ?? []);
    }
}
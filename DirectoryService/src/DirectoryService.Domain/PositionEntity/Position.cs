using CSharpFunctionalExtensions;
using DirectoryService.Domain.ConnectionEntity;
using Shared;

namespace DirectoryService.Domain.PositionEntity;

public sealed class Position
{
    public const short DESCRIPTION_MAX_LENGTH = 1500;

    public Guid Id { get; private set; }

    public Name Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentPosition> _departmentPositions = [];

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

    public bool EmptyPositions => _departmentPositions.Count == 0;

    // EF Core
    private Position() { }

    private Position(
        Name name,
        string? description,
        List<DepartmentPosition> departmentPositions,
        bool isActive)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Name = name;
        Description = description;
        _departmentPositions = departmentPositions;
        IsActive = isActive;
    }

    public static Result<Position, Failure> Create(
        Name name,
        string? description,
        IEnumerable<DepartmentPosition> departmentPositions,
        bool isActive)
    {
        if (description is { Length: > DESCRIPTION_MAX_LENGTH })
            return GeneralError.ValueIsInvalid("description position").ToFailure();

        return new Position(
            name,
            description,
            departmentPositions.ToList(),
            isActive);
    }
}
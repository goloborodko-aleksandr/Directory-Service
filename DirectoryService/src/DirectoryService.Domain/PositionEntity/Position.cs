using CSharpFunctionalExtensions;
using DirectoryService.Domain.ConnectionEntity;

namespace DirectoryService.Domain.PositionEntity;

public class Position
{
    public const short DESCRIPTION_MAX_LENGTH = 1500;

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private List<DepartmentPosition> _departmentPositions;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

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

    public static Result<Position> Create(
        Name name,
        string? description,
        List<DepartmentPosition>? departmentPositions,
        bool isActive)
    {
        if (departmentPositions == null)
            return Result.Failure<Position>("departmentPositions cannot be null");

        if (description is { Length: > DESCRIPTION_MAX_LENGTH })
            return Result.Failure<Position>("Description is too long");

        return new Position(
            name,
            description,
            departmentPositions,
            isActive);
    }
}
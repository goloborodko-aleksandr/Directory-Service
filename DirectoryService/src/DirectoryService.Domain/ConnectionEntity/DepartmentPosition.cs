using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.PositionEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public sealed class DepartmentPosition
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; } = null!;

    public Position Position { get; private set; } = null!;

    // EF Core
    private DepartmentPosition() { }

    public DepartmentPosition(
        Department department,
        Position position)
    {
        Id = Guid.NewGuid();
        Department = department;
        Position = position;
    }
}
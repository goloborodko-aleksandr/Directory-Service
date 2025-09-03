using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.PositionEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentPosition
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; }

    public Position Position { get; private set; }

    public DepartmentPosition(
        Department department,
        Position position)
    {
        Id = Guid.NewGuid();
        Department = department;
        Position = position;
    }
}
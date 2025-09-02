using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentEntity;
using DirectoryService.Domain.PositionEntity;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentPosition
{
    public Guid Id { get; private set; }

    public Department Department { get; private set; }

    public Position Position { get; private set; }

    private DepartmentPosition(
        Department department,
        Position position)
    {
        Id = Guid.NewGuid();
        Department = department;
        Position = position;
    }

    public static Result<DepartmentPosition> Create(
        Department department,
        Position position)
    {
        if (department == null || position == null)
            return Result.Failure<DepartmentPosition>("Department or Position cannot be null");

        return new DepartmentPosition(department, position);
    }
}
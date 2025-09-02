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
        Department = department;
        Position = position;
    }

    public static Result<DepartmentPosition> Create(
        Department? department,
        Position? position)
    {
        if (department == null)
            return Result.Failure<DepartmentPosition>("Department cannot be empty");

        if (position == null)
            return Result.Failure<DepartmentPosition>("Position cannot be empty");

        return new DepartmentPosition(department, position);
    }
}
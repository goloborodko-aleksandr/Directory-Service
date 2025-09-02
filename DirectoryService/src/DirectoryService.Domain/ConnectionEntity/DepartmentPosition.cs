using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentPosition
{
    public List<Guid> DepartmentId { get; private set; }

    public List<Guid> PositionId { get; private set; }

    private DepartmentPosition(
        List<Guid> departmentId,
        List<Guid> positionId)
    {
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public static Result<DepartmentPosition> Create(
        List<Guid>? departmentId,
        List<Guid>? positionId)
    {
        if (departmentId == null)
        {
            return Result.Failure<DepartmentPosition>("DepartmentId cannot be null");
        }

        if (positionId == null)
        {
            return Result.Failure<DepartmentPosition>("PositionId cannot be null");
        }

        return new DepartmentPosition(departmentId, positionId);
    }
}
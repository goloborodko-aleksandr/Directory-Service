using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.ConnectionEntity;

public class DepartmentLocation
{
    public List<Guid> DepartmentId { get; private set; }

    public List<Guid> LocationId { get; private set; }

    private DepartmentLocation(
        List<Guid> departmentId,
        List<Guid> locationId)
    {
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public static Result<DepartmentLocation> Create(
        List<Guid>? departmentId,
        List<Guid>? locationId)
    {
        if (departmentId == null)
        {
            return Result.Failure<DepartmentLocation>("DepartmentId cannot be null");
        }

        if (locationId == null)
        {
            return Result.Failure<DepartmentLocation>("PositionId cannot be null");
        }

        return new DepartmentLocation(departmentId, locationId);
    }
}
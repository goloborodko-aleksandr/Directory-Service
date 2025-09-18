using Shared;

namespace DirectoryService.Application.Locations.Exceptions;

public partial class Errors
{
    public static class Location
    {
            public static Error LocationNotFound(Guid? id) =>
                Error.NotFound("location.not.found", id, $"location not found with id {id.ToString() ?? "null"}");

            public static Error Validation(string? invalidField = null) =>
                Error.Validation("location.value.is.not.valid", $"value {invalidField ?? "unknown"} is not valid", invalidField);

            public static Error Failure() =>
                Error.Failure("location.failure", "Something is failed");

            public static Error Conflict() =>
                Error.Conflict("location.conflict", "Something is conflict");
    }

}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace DirectoryService.Presentation.Extensions;

public static class ResponseExtensions
{
    public static ActionResult ToResponse(this Failure failure)
    {
        if (!failure.Any()) return new ObjectResult(null) { StatusCode = StatusCodes.Status500InternalServerError };
        var typesGroup = failure
                .GroupBy(i => i.ErrorType)
                .Select(i => i.Key)
                .ToArray();
        bool hasMoreOneType = typesGroup.Length > 1;
        return new ObjectResult(failure) { StatusCode = hasMoreOneType ? StatusCodes.Status500InternalServerError : typesGroup.First().ToStatusCode(), };
    }

    private static int ToStatusCode(this ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.FAILURE => StatusCodes.Status500InternalServerError,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}
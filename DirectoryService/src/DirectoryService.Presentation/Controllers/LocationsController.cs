using DirectoryService.Application.Locations.Services;
using DirectoryService.Contracts.Locations;
using DirectoryService.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation(
        [FromBody] CreateLocationDto createLocationDto,
        [FromServices] CreateLocationHandler createLocationHandler, CancellationToken cancellationToken)
    {
        var result = await createLocationHandler.Handle(createLocationDto, cancellationToken);
        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }

        return Ok(result.Value);
    }
}
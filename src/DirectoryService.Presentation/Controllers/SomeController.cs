using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SomeController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> SomeGet()
    {
        return Ok("все ок");
    }
}
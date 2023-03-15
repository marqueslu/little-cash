using Microsoft.AspNetCore.Mvc;

namespace LittleCash.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Repository;

namespace NewApp.Controllers;

[ApiController]
[Route("api/balance/new/v1/[controller]")]
public class HealthController : ControllerBase
{
    private readonly IInsertRecord _repository;

    public HealthController(IInsertRecord repository)
    {
        _repository = repository;
    }

    [HttpGet("check")]
    public ActionResult<string> HealthCheck()
    {
        return Ok("HEALTHY");
    }
}
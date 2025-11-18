using Microsoft.AspNetCore.Mvc;
using Repository;

namespace OldApp.Controllers;

[ApiController]
[Route("api/balance/old/v1/[controller]")]
public class MainController : ControllerBase
{
    private readonly IInsertRecord _repository;

    public MainController(IInsertRecord repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<InsertResponse>> Insert()
    {
        return Ok(await _repository.InsertData("OLD"));
    }

    [HttpGet("{value}")]
    public async Task<ActionResult<InsertResponse>> Get(string value)
    {
        return Ok(await _repository.InsertData($"OLD_{value}"));
    }

    [HttpGet("novalue")]
    public async Task<ActionResult<InsertResponse>> NoValue()
    {
        return Ok(await _repository.InsertData($"OLD_NOVALUE"));
    }

    [HttpGet("{value}/after")]
    public async Task<ActionResult<InsertResponse>> GetAfter(string value)
    {
        return Ok(await _repository.InsertData($"OLD_{value}_AFTER"));
    }

    [HttpGet("alternative-route/{value}/first")]
    public async Task<ActionResult<InsertResponse>> FirstAlternativeRoute(string value)
    {
        return Ok(await _repository.InsertData($"OLD_{value}_FIRST_ALTERNATIVE_ROUTE"));
    }

    [HttpGet("alternative-route/{value}/second")]
    public async Task<ActionResult<InsertResponse>> SecondAlternativeRoute(string value)
    {
        return Ok(await _repository.InsertData($"OLD_{value}_SECOND_ALTERNATIVE_ROUTE"));
    }
}

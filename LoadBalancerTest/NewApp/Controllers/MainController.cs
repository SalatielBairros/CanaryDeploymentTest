using Microsoft.AspNetCore.Mvc;
using Repository;

namespace NewApp.Controllers;

[ApiController]
[Route("api/balance/new/v1/[controller]")]
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
        return Ok(await _repository.InsertData("NEW"));
    }

    [HttpGet("{value}")]
    public async Task<ActionResult<InsertResponse>> Get(string value)
    {
        return Ok(await _repository.InsertData($"NEW_{value}"));
    }

    [HttpGet("novalue")]
    public async Task<ActionResult<InsertResponse>> NoValue()
    {
        return Ok(await _repository.InsertData($"NEW_NOVALUE"));
    }

    [HttpGet("{value}/after")]
    public async Task<ActionResult<InsertResponse>> GetAfter(string value)
    {
        return Ok(await _repository.InsertData($"NEW_{value}_AFTER"));
    }
}

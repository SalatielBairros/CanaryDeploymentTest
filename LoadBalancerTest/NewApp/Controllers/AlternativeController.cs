using Microsoft.AspNetCore.Mvc;
using Repository;

namespace NewApp.Controllers;

[ApiController]
[Route("api/balance/new/v1/[controller]")]
public class AlternativeController : ControllerBase
{
    private readonly IInsertRecord _repository;

    public AlternativeController(IInsertRecord repository)
    {
        _repository = repository;
    }

    [HttpGet("{value}")]
    public async Task<ActionResult<InsertResponse>> GetAfter(string value)
    {
        return Ok(await _repository.InsertData($"NEW_{value}_ALTERNATIVE"));
    }
}
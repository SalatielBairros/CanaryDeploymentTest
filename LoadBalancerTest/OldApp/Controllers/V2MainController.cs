using Microsoft.AspNetCore.Mvc;
using Repository;

namespace OldApp.Controllers;

[ApiController]
[Route("api/balance/old/v2/[controller]")]
public class V2MainController : ControllerBase
{
    private readonly IInsertRecord _repository;

    public V2MainController(IInsertRecord repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<InsertResponse>> Insert()
    {
        return Ok(await _repository.InsertData("OLD"));
    }
}
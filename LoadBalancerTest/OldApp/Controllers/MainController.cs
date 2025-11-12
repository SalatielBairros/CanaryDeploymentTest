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
}

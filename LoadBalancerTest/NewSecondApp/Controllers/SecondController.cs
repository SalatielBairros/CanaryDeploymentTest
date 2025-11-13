using Microsoft.AspNetCore.Mvc;
using Repository;

namespace NewSecondApp.Controllers;

[ApiController]
[Route("api/balance/new-second/v1/[controller]")]
public class SecondController : ControllerBase
{
    private readonly IInsertRecord _repository;

    public SecondController(IInsertRecord repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<InsertResponse>> Insert()
    {
        return Ok(await _repository.InsertData("SECOND_NEW"));
    }
}

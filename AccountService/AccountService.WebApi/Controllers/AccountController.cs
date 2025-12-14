using Microsoft.AspNetCore.Mvc;

namespace AccountService.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController() : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

using AccountService.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

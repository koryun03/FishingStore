using AccountService.Core.Models;
using AccountService.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model, CancellationToken cancellationToken)
    {
        await accountService.RegisterAsync(model.adapt, cancellationToken);

        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

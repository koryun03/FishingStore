using AccountService.Core.Dtos;
using AccountService.Core.Models;
using AccountService.Core.ServiceInterfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model, CancellationToken cancellationToken)
    {
        await userService.RegisterAsync(model.Adapt<RegisterDto>(), cancellationToken);

        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Model.Base;
using Services;

namespace Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AccountService _accountService;

    public UserController(UserService userService, AccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var user = _userService.Get();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {   
        await _accountService.CreateAccount(user);
        _userService.AddUser(user);

        return Ok();
    }
}
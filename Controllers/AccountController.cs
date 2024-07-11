using Microsoft.AspNetCore.Mvc;
using Model.Base;
using Services;
using Services.Requests;

namespace Controllers;

[ApiController]
[Route("api/v1/user")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(UserService userService, AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("transfer")]
    public IActionResult TransferFunds([FromBody] TransferRequest transferRequest)
    {
        try
        {
            _accountService.TransferFunds(transferRequest.Amount, transferRequest.FromAccountNumber, transferRequest.ToAccountNumber);
            return Ok(new {Message = "Transfer successful"});
        }
        catch (Exception ex)
        {
            return BadRequest( new {Message = ex.Message});
        }
    }
}
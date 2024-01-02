using BlogDotNet6.Services;
using BlogDotNet6.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet6.Controllers;

[ApiController]
public class AccountController : ControllerBase

{
    [HttpPost("v1/login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);
        return Ok(new ResultViewModel<string>(token));
        
    }

    [HttpGet("v1/me")]
    public IActionResult Me()
        => Ok(User.Identity.Name);
    
    [HttpGet("v1/admin")]
    public IActionResult Admin()
        => Ok("Admin");
    
    
}
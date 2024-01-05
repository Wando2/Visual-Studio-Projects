using BlogDotNet6.Data;
using BlogDotNet6.Extensions;
using BlogDotNet6.Models;
using BlogDotNet6.Services;
using BlogDotNet6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet6.Controllers;

[ApiController]
public class AccountController : ControllerBase

{
    [HttpPost("v1/accounts/register")]
    public async Task<IActionResult> Register([FromServices] BlogDataContext context, [FromBody] RegisterUserViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Name.ToLower().Replace(" ", "-")
                
                
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Created($"v1/accounts/{user.Id}", new ResultViewModel<User>(user));
        }
        catch (DbUpdateException)
        {
            return BadRequest(new ResultViewModel<User>("01 - An error occurred while registering the user"));
        }
    }
    
    
    [HttpPost("v1/accounts/login")]
    public IActionResult Login([FromServices]TokenService tokenService)
    {
        var token = tokenService.GenerateToken(null);
        return Ok(new ResultViewModel<string>(token));
        
    }


    
}
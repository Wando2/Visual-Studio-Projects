using System.Text.RegularExpressions;
using BlogDotNet6.Data;
using BlogDotNet6.Extensions;
using BlogDotNet6.Models;
using BlogDotNet6.Services;
using BlogDotNet6.ViewModels;
using BlogDotNet6.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet6.Controllers;

[ApiController]
public class AccountController : ControllerBase

{
    [HttpPost("v1/accounts/register")]
    public async Task<IActionResult> Register([FromServices] BlogDataContext context, [FromBody] RegisterUserViewModel model)
    {
       
        
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Name.ToLower().Replace(" ", "-"),
                Bio = "Bio em branco",
                Image = "https://static.productionready.io/images/smiley-cyrus.jpg",

                
                
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

        try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<dynamic>(new {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Slug,
                    user.PasswordHash,
                
                
                }));
            } catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<User>("01 - The email is already registered"));
            }
            catch (Exception e)
            {
               return StatusCode(500, new ResultViewModel<User>(e.Message));

            }

       
       
    }
    
    
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromServices]TokenService tokenService,
        [FromServices] BlogDataContext context,
        [FromBody] LoginUserViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

        var user = await context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == model.Email);

        if (user == null)
            return NotFound(new ResultViewModel<User>("01 - The user couldn't be found"));

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
            return BadRequest(new ResultViewModel<User>("01 - The password is invalid"));

        try
        {
            var token = tokenService.GenerateToken(user);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<User>(e.Message));
        }
    }

    
    [Authorize]
    [HttpPost("v1/accounts/upload-image")]
    public async Task<IActionResult> UploadImage(
        [FromBody] UploadImageViewModel model,
        [FromServices] BlogDataContext context 
    )
    {
        var fileName = $"{Guid.NewGuid()}.jpg";
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.ImageBase64, string.Empty);
            
        var bytes = Convert.FromBase64String(data);

        try
        {
            await System.IO.File.WriteAllBytesAsync($"./wwwroot/{fileName}", bytes);
        } catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<User>(e.Message));
        }
        
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.name);
        

    }
    
}
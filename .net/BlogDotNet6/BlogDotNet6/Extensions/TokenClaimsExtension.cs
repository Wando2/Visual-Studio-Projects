using System.Security.Claims;
using BlogDotNet6.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogDotNet6.Extensions;

public static class RoleClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Email, user.Name),
            new Claim("Bio", user.Bio),
            new Claim("Image", user.Image),
           
        };

        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        return claims;
    }
}

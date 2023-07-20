using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Model;
using WebApiExample.Services;

namespace WebApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService) : base()
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest.Username != "andrea" || loginRequest.Password != "123")
            return Unauthorized(new { Message = "Unauthorized" });
      
        var jwt = _jwtService.GetTokenFromClaims(new[]
        {
            new Claim(ClaimTypes.Name, loginRequest.Username),
            new Claim(ClaimTypes.Email, "mail@test.com")
        });
        
        SetAuthCookie(jwt);

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        RemoveAuthCookie();
        return Ok();
    }

    private void SetAuthCookie(string jwt)
    {
        HttpContext.Response.Cookies.Append("token", jwt, new CookieOptions()
        {
            Expires = DateTime.Now.AddSeconds(60 * 20), // 20 minutes
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        });
    }

    private void RemoveAuthCookie()
    {
        HttpContext.Response.Cookies.Delete("token");
    }
}


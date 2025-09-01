
using Microsoft.AspNetCore.Mvc;
using Fintcs.API.Services;
using Fintcs.API.DTOs;

namespace Fintcs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var result = await _authService.LoginAsync(loginDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        try
        {
            var result = await _authService.RefreshTokenAsync(refreshTokenDto.Token);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }
}

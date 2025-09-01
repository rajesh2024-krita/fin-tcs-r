
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.DTOs;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}

public class LoginResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public UserInfoDto User { get; set; }
}

public class UserInfoDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int? SocietyId { get; set; }
    public string SocietyName { get; set; }
}

public class RefreshTokenDto
{
    [Required]
    public string Token { get; set; }
}

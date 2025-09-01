
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Fintcs.API.Data;
using Fintcs.API.DTOs;
using Fintcs.API.Models;

namespace Fintcs.API.Services;

public class AuthService : IAuthService
{
    private readonly FintcsDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(FintcsDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        try
        {
            // Check SuperAdmin first
            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(sa => sa.Username == loginDto.Username);
            
            if (superAdmin != null && VerifyPassword(loginDto.Password, superAdmin.PasswordHash))
            {
                var token = GenerateJwtToken("SuperAdmin", superAdmin.Id, superAdmin.Username, "Super Admin", null);
                return new LoginResponseDto
                {
                    Success = true,
                    Message = "Login successful",
                    Token = token,
                    User = new UserInfoDto
                    {
                        Id = superAdmin.Id,
                        Username = superAdmin.Username,
                        Name = "Super Admin",
                        Role = "SuperAdmin",
                        SocietyId = null,
                        SocietyName = null
                    }
                };
            }

            // Check AppUsers
            var user = await _context.AppUsers
                .Include(u => u.Society)
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.IsActive);

            if (user != null && VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                var token = GenerateJwtToken(user.Role, user.Id, user.Username, user.Name, user.SocietyId);
                return new LoginResponseDto
                {
                    Success = true,
                    Message = "Login successful",
                    Token = token,
                    User = new UserInfoDto
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Name = user.Name,
                        Role = user.Role,
                        SocietyId = user.SocietyId,
                        SocietyName = user.Society?.Name
                    }
                };
            }

            return new LoginResponseDto
            {
                Success = false,
                Message = "Invalid username or password"
            };
        }
        catch (Exception ex)
        {
            return new LoginResponseDto
            {
                Success = false,
                Message = "Login failed: " + ex.Message
            };
        }
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(string refreshToken)
    {
        // Implementation for refresh token logic
        return new LoginResponseDto
        {
            Success = false,
            Message = "Refresh token not implemented yet"
        };
    }

    private string GenerateJwtToken(string role, int userId, string username, string name, int? societyId)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"]);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim("Name", name),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (societyId.HasValue)
        {
            claims.Add(new Claim("SocietyId", societyId.Value.ToString()));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private bool VerifyPassword(string password, string hash)
    {
        // For demo purposes, using simple comparison
        // In production, use proper password hashing like BCrypt
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}

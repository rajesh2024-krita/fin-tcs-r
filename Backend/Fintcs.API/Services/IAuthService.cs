
using Fintcs.API.DTOs;

namespace Fintcs.API.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    Task<LoginResponseDto> RefreshTokenAsync(string refreshToken);
}

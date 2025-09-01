
using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetUserByIdAsync(int id);
        Task<AppUser> CreateUserAsync(AppUser user);
        Task<AppUser?> UpdateUserAsync(int id, AppUser user);
        Task<bool> DeleteUserAsync(int id);
    }
}

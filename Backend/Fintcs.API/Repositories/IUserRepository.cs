
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<AppUser?> GetByIdAsync(int id);
        Task<AppUser> CreateAsync(AppUser user);
        Task<AppUser?> UpdateAsync(int id, AppUser user);
        Task<bool> DeleteAsync(int id);
    }
}

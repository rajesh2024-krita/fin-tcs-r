
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public interface ISocietyRepository
    {
        Task<IEnumerable<Society>> GetAllAsync();
        Task<Society?> GetByIdAsync(int id);
        Task<Society> CreateAsync(Society society);
        Task<Society?> UpdateAsync(int id, Society society);
        Task<bool> DeleteAsync(int id);
    }
}

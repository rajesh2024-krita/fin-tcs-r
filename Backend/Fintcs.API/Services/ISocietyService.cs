
using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public interface ISocietyService
    {
        Task<IEnumerable<Society>> GetAllSocietiesAsync();
        Task<Society?> GetSocietyByIdAsync(int id);
        Task<Society> CreateSocietyAsync(Society society);
        Task<Society?> UpdateSocietyAsync(int id, Society society);
        Task<bool> DeleteSocietyAsync(int id);
    }
}

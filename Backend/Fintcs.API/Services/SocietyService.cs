
using Fintcs.API.Models;
using Fintcs.API.Repositories;

namespace Fintcs.API.Services
{
    public class SocietyService : ISocietyService
    {
        private readonly ISocietyRepository _societyRepository;

        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository;
        }

        public async Task<IEnumerable<Society>> GetAllSocietiesAsync()
        {
            return await _societyRepository.GetAllAsync();
        }

        public async Task<Society?> GetSocietyByIdAsync(int id)
        {
            return await _societyRepository.GetByIdAsync(id);
        }

        public async Task<Society> CreateSocietyAsync(Society society)
        {
            return await _societyRepository.CreateAsync(society);
        }

        public async Task<Society?> UpdateSocietyAsync(int id, Society society)
        {
            return await _societyRepository.UpdateAsync(id, society);
        }

        public async Task<bool> DeleteSocietyAsync(int id)
        {
            return await _societyRepository.DeleteAsync(id);
        }
    }
}

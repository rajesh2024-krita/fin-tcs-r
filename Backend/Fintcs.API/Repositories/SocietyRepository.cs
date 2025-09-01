
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly FintcsDbContext _context;

        public SocietyRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Society>> GetAllAsync()
        {
            return await _context.Societies.ToListAsync();
        }

        public async Task<Society?> GetByIdAsync(int id)
        {
            return await _context.Societies.FindAsync(id);
        }

        public async Task<Society> CreateAsync(Society society)
        {
            _context.Societies.Add(society);
            await _context.SaveChangesAsync();
            return society;
        }

        public async Task<Society?> UpdateAsync(int id, Society society)
        {
            var existing = await _context.Societies.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(society);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var society = await _context.Societies.FindAsync(id);
            if (society == null) return false;

            _context.Societies.Remove(society);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

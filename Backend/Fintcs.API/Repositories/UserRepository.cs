
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FintcsDbContext _context;

        public UserRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser?> GetByIdAsync(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> CreateAsync(AppUser user)
        {
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<AppUser?> UpdateAsync(int id, AppUser user)
        {
            var existing = await _context.AppUsers.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user == null) return false;

            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

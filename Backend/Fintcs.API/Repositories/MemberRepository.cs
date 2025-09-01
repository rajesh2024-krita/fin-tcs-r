
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FintcsDbContext _context;

        public MemberRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<Member> CreateAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member?> UpdateAsync(int id, Member member)
        {
            var existing = await _context.Members.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(member);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return false;

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

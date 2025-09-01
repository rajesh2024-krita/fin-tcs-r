
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly FintcsDbContext _context;

        public VoucherRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voucher>> GetAllAsync()
        {
            return await _context.Vouchers.ToListAsync();
        }

        public async Task<Voucher?> GetByIdAsync(int id)
        {
            return await _context.Vouchers.FindAsync(id);
        }

        public async Task<Voucher> CreateAsync(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
            return voucher;
        }

        public async Task<Voucher?> UpdateAsync(int id, Voucher voucher)
        {
            var existing = await _context.Vouchers.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(voucher);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null) return false;

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

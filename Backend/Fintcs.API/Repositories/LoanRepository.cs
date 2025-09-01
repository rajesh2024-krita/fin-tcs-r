
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Data;
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly FintcsDbContext _context;

        public LoanRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<Loan> CreateAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan?> UpdateAsync(int id, Loan loan)
        {
            var existing = await _context.Loans.FindAsync(id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(loan);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return false;

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

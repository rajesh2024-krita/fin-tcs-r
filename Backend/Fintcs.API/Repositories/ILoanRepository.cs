
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<Loan> CreateAsync(Loan loan);
        Task<Loan?> UpdateAsync(int id, Loan loan);
        Task<bool> DeleteAsync(int id);
    }
}

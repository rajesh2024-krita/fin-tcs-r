
using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan?> GetLoanByIdAsync(int id);
        Task<Loan> CreateLoanAsync(Loan loan);
        Task<Loan?> UpdateLoanAsync(int id, Loan loan);
        Task<bool> DeleteLoanAsync(int id);
        Task<bool> ValidateLoanAsync(int id);
    }
}

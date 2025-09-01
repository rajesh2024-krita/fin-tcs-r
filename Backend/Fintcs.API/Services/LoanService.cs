
using Fintcs.API.Models;
using Fintcs.API.Repositories;

namespace Fintcs.API.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _loanRepository.GetAllAsync();
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _loanRepository.GetByIdAsync(id);
        }

        public async Task<Loan> CreateLoanAsync(Loan loan)
        {
            return await _loanRepository.CreateAsync(loan);
        }

        public async Task<Loan?> UpdateLoanAsync(int id, Loan loan)
        {
            return await _loanRepository.UpdateAsync(id, loan);
        }

        public async Task<bool> DeleteLoanAsync(int id)
        {
            return await _loanRepository.DeleteAsync(id);
        }

        public async Task<bool> ValidateLoanAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan == null) return false;
            
            // Add loan validation logic here
            return true;
        }
    }
}

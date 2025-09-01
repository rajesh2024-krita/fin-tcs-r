
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public interface IVoucherRepository
    {
        Task<IEnumerable<Voucher>> GetAllAsync();
        Task<Voucher?> GetByIdAsync(int id);
        Task<Voucher> CreateAsync(Voucher voucher);
        Task<Voucher?> UpdateAsync(int id, Voucher voucher);
        Task<bool> DeleteAsync(int id);
    }
}


using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public interface IVoucherService
    {
        Task<IEnumerable<Voucher>> GetAllVouchersAsync();
        Task<Voucher?> GetVoucherByIdAsync(int id);
        Task<Voucher> CreateVoucherAsync(Voucher voucher);
        Task<Voucher?> UpdateVoucherAsync(int id, Voucher voucher);
        Task<bool> DeleteVoucherAsync(int id);
        Task<bool> ReverseVoucherAsync(int id);
    }
}

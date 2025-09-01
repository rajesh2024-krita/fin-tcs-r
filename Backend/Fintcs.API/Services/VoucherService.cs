
using Fintcs.API.Models;
using Fintcs.API.Repositories;

namespace Fintcs.API.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<IEnumerable<Voucher>> GetAllVouchersAsync()
        {
            return await _voucherRepository.GetAllAsync();
        }

        public async Task<Voucher?> GetVoucherByIdAsync(int id)
        {
            return await _voucherRepository.GetByIdAsync(id);
        }

        public async Task<Voucher> CreateVoucherAsync(Voucher voucher)
        {
            return await _voucherRepository.CreateAsync(voucher);
        }

        public async Task<Voucher?> UpdateVoucherAsync(int id, Voucher voucher)
        {
            return await _voucherRepository.UpdateAsync(id, voucher);
        }

        public async Task<bool> DeleteVoucherAsync(int id)
        {
            return await _voucherRepository.DeleteAsync(id);
        }

        public async Task<bool> ReverseVoucherAsync(int id)
        {
            var voucher = await _voucherRepository.GetByIdAsync(id);
            if (voucher == null) return false;
            
            // Add voucher reversal logic here
            return true;
        }
    }
}

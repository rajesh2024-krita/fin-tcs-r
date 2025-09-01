
namespace Fintcs.API.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateFinancialReportAsync(int societyId, DateTime fromDate, DateTime toDate);
        Task<byte[]> GenerateLoanReportAsync(int societyId);
        Task<byte[]> GenerateMemberReportAsync(int societyId);
        Task<byte[]> GenerateMonthlyDemandReportAsync(int societyId, int month, int year);
    }
}

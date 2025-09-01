
using Fintcs.API.Models;

namespace Fintcs.API.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member> CreateAsync(Member member);
        Task<Member?> UpdateAsync(int id, Member member);
        Task<bool> DeleteAsync(int id);
    }
}

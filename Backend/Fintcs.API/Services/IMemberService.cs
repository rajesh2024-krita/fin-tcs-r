
using Fintcs.API.Models;

namespace Fintcs.API.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member?> GetMemberByIdAsync(int id);
        Task<Member> CreateMemberAsync(Member member);
        Task<Member?> UpdateMemberAsync(int id, Member member);
        Task<bool> DeleteMemberAsync(int id);
    }
}

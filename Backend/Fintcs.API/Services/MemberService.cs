
using Fintcs.API.Models;
using Fintcs.API.Repositories;

namespace Fintcs.API.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            return await _memberRepository.CreateAsync(member);
        }

        public async Task<Member?> UpdateMemberAsync(int id, Member member)
        {
            return await _memberRepository.UpdateAsync(id, member);
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            return await _memberRepository.DeleteAsync(id);
        }
    }
}

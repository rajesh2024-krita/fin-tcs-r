
using Fintcs.API.Models;
using Fintcs.API.Repositories;

namespace Fintcs.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<AppUser> CreateUserAsync(AppUser user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<AppUser?> UpdateUserAsync(int id, AppUser user)
        {
            return await _userRepository.UpdateAsync(id, user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}

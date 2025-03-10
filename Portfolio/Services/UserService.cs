using Portfolio.Repositories;
using Portfolio.ViewModel;

namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Login(LoginVM loginVM)
        {
            return await _userRepository.Login(loginVM);
        }

        public async Task<string> Logout(LogoutVM logoutVM)
        {
            return await _userRepository.Logout(logoutVM);
        }

        public async Task<string> LogoutAllDevice(int userId)
        {
            return await _userRepository.LogoutAllDevice(userId);
        }

        public async Task<string> RefreshToken(RefreshVM refreshVM)
        {
            return await _userRepository.RefreshToken(refreshVM);
        }
    }
}

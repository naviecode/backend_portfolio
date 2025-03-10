using Portfolio.ViewModel;

namespace Portfolio.Services
{
    public interface IUserService
    {
        Task<string> Login(LoginVM loginVM);
        Task<string> Logout(LogoutVM logoutVM);
        Task<string> RefreshToken(RefreshVM refreshVM);
        Task<string> LogoutAllDevice(int userId);
    }
}
